using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class UIManager
{
    private IUIState currentState;

    private readonly Dictionary<GameState, IUIState> stateDictionary = new Dictionary<GameState, IUIState>();
    
    private const string UIViewPath = "UI/";
    private readonly Dictionary<string, UIView> uiViewDictionary = new Dictionary<string, UIView>();
    
    private readonly Dictionary<string, UIMissionView> _uiMissionDictionary = new Dictionary<string, UIMissionView>();

    public void Init()
    {
        stateDictionary.Add(GameState.Ttitle, new TitleState());
        stateDictionary.Add(GameState.Platformer, new PlatformerState());
        stateDictionary.Add(GameState.Dialogue, new DialogueState());
        stateDictionary.Add(GameState.End, new EndState());
    }
    
    public void ChangeState(GameState stateType)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        if (stateDictionary.TryGetValue(stateType, out var state))
        {
            currentState = state;
            currentState.OnEnter();
        }
    }
    
    public UIView GetUIView(string uiViewName)
    {
        try
        {
            var uiViewPrefab = GameObject.Find(uiViewName)?.GetComponent<UIView>();
            if (uiViewPrefab != null)
            {
                return uiViewPrefab;
            }

            if (_uiMissionDictionary.ContainsKey(uiViewName))
            {
                return _uiMissionDictionary[uiViewName];
            }

            uiViewPrefab = GameManager.Resource.Load<UIView>(UIViewPath + uiViewName);
            if (uiViewPrefab == null)
            {
                throw new Exception("Resource 폴더에 없거나 씬에 존재하지 않는 UIView입니다..! : " + uiViewName + "을 확인해주세요!");
            }

            uiViewPrefab = GameObject.Instantiate(uiViewPrefab);
            uiViewPrefab.name = uiViewName;
            
            if (uiViewPrefab.TryGetComponent<UIMissionView>(out var uiMissionView))
            {
                _uiMissionDictionary.Add(uiViewName, uiMissionView);
            }
            
            return uiViewPrefab;
        }
        catch (Exception e)
        {
            Debug.LogWarning(e);
        }

        return null;
    }
    
    public UIView PopupPush(string uiViewName)
    {
        var view = GameManager.UI.GetUIView(uiViewName);
        
        if (view == null)
        {
            Debug.LogError($"[UIManager] PopupPush Error: {uiViewName}");
            return null;
        }
        
        view.Show();

        return view;
    }
    
    public UIView PopupPop(Queue<UIView> uiViews)
    {
        UIView view = null;
        if (uiViews.Count > 0)
        {
            view = uiViews.Dequeue();
            view.Hide();
        }
        
        return view;
    }
}
