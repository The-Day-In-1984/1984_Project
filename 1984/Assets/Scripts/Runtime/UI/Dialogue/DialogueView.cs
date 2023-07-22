using System;
using System.Collections.Generic;
using Enums;
using Structs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : UIView
{
    enum state
    {
        dialogue,
        option
    }
    private state _state = state.dialogue;
    private List<StoryData> _storyDataList;
    private GameObject _optionPanel;
    private GameObject _optionGameObject;
    private List<Image> _characterImgList = new List<Image>();
    private TextMeshProUGUI _sceneText;
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _optionText;
    private List<GameObject> _optionGameObjectList = new List<GameObject>();
    private Image _backgroundImg;
    private int _currentIdx = -1;
    private string _nextId = "0";
    private readonly string _dialoguePath = "Dialogue/";
    private TypingEffect _typingEffect;

    private bool _isTurnOffLastImg = false;
    private Image _lastImg;
    private void Awake()
    {
        _characterImgList.Add(GameObject.Find("RightCharacterImg").GetComponent<Image>());
        _characterImgList.Add(GameObject.Find("LeftCharacterImg").GetComponent<Image>());
        _sceneText =  GameObject.Find("SceneText").GetComponent<TextMeshProUGUI>();
        _nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        _dialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        _optionPanel = GameObject.Find("OptionPanel");
        _optionGameObject = GameObject.Find("OptionButton");
        _backgroundImg = GameObject.Find("BackgroundImg").GetComponent<Image>();
        _typingEffect = gameObject.AddComponent<TypingEffect>();
    }

    private void Start()
    {
        _typingEffect.Init(_dialogueText);
    }

    public override void Show()
    {
        StartDialogue(GameManager.Data._curDialogueId);
        
    }
    public override void Hide()
    {
        SetId();
        GameManager.UI.ChangeState(GameState.Platformer);
    }
    private void SetId()
    {
        _nextId = (Int32.Parse(_nextId) + 1).ToString() ;
        GameManager.Data._curDialogueId = _nextId;
        Debug.Log(GameManager.Data._curDialogueId);
    }
    
    public void StartDialogue(string id)
    {
        GotoId(id);
        InitBackgroundImg();
        InitSceneText();
        _optionPanel.SetActive(false);
        _optionGameObject.SetActive(false);
    }
    private void GotoId(string id)
    {
        _currentIdx = -1;
        _storyDataList = GameManager.Data.StoryData[id];
    }
    private void InitBackgroundImg()
    {
        _backgroundImg.sprite = GameManager.Resource.LoadSprite(_dialoguePath + _storyDataList[0].Scene);
    }
    private void InitSceneText()
    {
        _sceneText.text = _storyDataList[0].Scene.ToUpper(); 
    }

    public void Run()
    {
        if (_state == state.option) return;
        if(_typingEffect.IsTypingNull()) ChangeDialogue();
        if (IsFinishDialogue())
        {
            Hide();
            return;
        }
        
        if (_storyDataList[_currentIdx].Type == "Option" && _storyDataList == GameManager.Data.StoryData[_nextId]) _state = state.option;
        switch (_state)
        {
            case state.dialogue:
                ShowDialogue();
                break;
            case state.option:
                ShowOption();
                break;
        }
    }
    private bool IsFinishDialogue()
    {
        return _currentIdx >= _storyDataList.Count;
    }
    private void ChangeDialogue()
    {
        if(_currentIdx == -1)
            ++_currentIdx;
        else if (!_storyDataList[_currentIdx].Goto.IsUnityNull())
        {
            _nextId = _storyDataList[_currentIdx].Goto;
            GotoId(_nextId);
            ChangeDialogue();
        }
        else
            ++_currentIdx;
    }

    private void ShowDialogue()
    {
        _state = state.dialogue;
        ChangeCharacterImg();
        ChangeTexts();
    }

    private void ChangeTexts()
    {
        if (_storyDataList[_currentIdx].Character == "None")
            _nameText.text = "";
        else
            _nameText.text = _storyDataList[_currentIdx].Character;
        _typingEffect.StartTyping(_storyDataList[_currentIdx].Text);
    }

    private void ChangeCharacterImg()
    {
        string characterName = _storyDataList[_currentIdx].Character+_storyDataList[_currentIdx].State;
        bool isNew = true;

        if (_isTurnOffLastImg)
        {
            _lastImg.sprite = GameManager.Resource.LoadSprite(_dialoguePath + "NoneIdle");
            _isTurnOffLastImg = false;
        }
        foreach (var img in _characterImgList)
        {
            
            if (img.sprite.name == characterName)
            {
                img.color = Color.white;
                isNew = false;
            }
            else
            {
                img.color = new Color(1, 1, 1, 0.5f);
            }
        }
        
        if (isNew)
        {
            foreach (var img in _characterImgList)
            {
                if (img.sprite.name == "NoneIdle")
                {
                    img.sprite = GameManager.Resource.LoadSprite(_dialoguePath + characterName);
                    img.color = Color.white;
                    break;
                }
            }
        }
        
        if (_storyDataList[_currentIdx].Active == "false")
        {
            foreach (var img in _characterImgList)
            {
                if (img.sprite.name == characterName)
                {
                    _lastImg = img;
                    _isTurnOffLastImg = true;
                    break;
                }
            }
        }
    }

    private void ShowOption()
    {
        _state = state.option;
        _optionPanel.SetActive(true);
        for (int i = 0; i < GetOptionCount(); i++)
        {
            _optionGameObjectList.Add(Instantiate(_optionGameObject));
            InitOptionButton(_optionGameObjectList[^1], i);
        }
    }
    private void InitOptionButton(GameObject optionObj, int i)
    {
        int idx = _currentIdx + i;
        optionObj.GetComponent<RectTransform>().anchoredPosition =
            new Vector3(Screen.width * 0.5f, Screen.height * 0.5f - 60 * GetOptionCount() * i + 60 * GetOptionCount());
        optionObj.transform.parent = _optionPanel.transform;
        optionObj.GetComponent<Button>().onClick.AddListener(() => SelectOption(_storyDataList[idx].Goto, idx));
        optionObj.GetComponentInChildren<TextMeshProUGUI>().text = _storyDataList[idx].Text;
        optionObj.SetActive(true);
    }
    private int GetOptionCount()
    {
        return _storyDataList.Count - _currentIdx;
    }
    private void SelectOption(string id, int idx)
    {
        _currentIdx = idx;
        _nextId = id;
        _state = state.dialogue;
        ShowDialogue();
        CloseOptions();
    }
    private void CloseOptions()
    {
        foreach (var obj in _optionGameObjectList)
        {
            Destroy(obj);
        }
        _optionGameObjectList.Clear();
        _optionPanel.SetActive(false);
    }
    public void Skip()
    {
        Hide();
    }
    
}