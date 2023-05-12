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
            var uiViewPrefabs = GameObject.Find(uiViewName)?.GetComponent<UIView>();
            if (uiViewPrefabs != null)
            {
                uiViewDictionary.Add(uiViewName, uiViewPrefabs);
                return uiViewPrefabs;
            }
                
            if (uiViewDictionary.TryGetValue(uiViewName, out UIView uiView))
            {
                return uiView;
            }

            var uiViewPrefab = GameManager.Resource.Load<UIView>(UIViewPath + uiViewName);
            if (uiViewPrefab == null)
            {
                throw new Exception("Resource 폴더에 없거나 씬에 존재하지 않는 UIView입니다..! : " + uiViewName + "을 확인해주세요!");
            }

            uiView = GameObject.Instantiate(uiViewPrefab);
            uiView.name = uiViewName;

            uiViewDictionary.Add(uiViewName, uiView);

            return uiView;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }
    
}
