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
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _optionText;
    private List<GameObject> _optionGameObjectList = new List<GameObject>();
    private Image _backgroundImg;
    private int _currentIdx = -1;
    private string _nextId = "0";
    private readonly string _dialoguePath = "Dialogue/";
    private Dictionary<string, Color> _characterColors = new Dictionary<string, Color>();
    private TypingEffect _typingEffect;
    private void Awake()
    {
        _characterImgList.Add(GameObject.Find("LeftCharacterImg").GetComponent<Image>());
        _characterImgList.Add(GameObject.Find("RightCharacterImg").GetComponent<Image>());
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
        StartDialogue("0");
        
    }
    public override void Hide()
    {
        GameManager.UI.ChangeState(GameState.Platformer);
    }
    
    public void StartDialogue(string id)
    {
        GotoId(id);
        InitBackgroundImg();
        InitCharacter();
        _optionPanel.SetActive(false);
        _optionGameObject.SetActive(false);
    }
    private void GotoId(string id)
    {
        _currentIdx = -1;
        _storyDataList = GameManager.Data.StoryData[id];
    }
    private void InitCharacter()
    {
        string imgStr1 = _storyDataList[0].Character + _storyDataList[0].State;
        _characterImgList[0].sprite = GameManager.Resource.LoadSprite(_dialoguePath + imgStr1);
        _characterColors.Add(imgStr1,new Color(1,1,1,0));
        foreach (var storyData in _storyDataList)
        {
            string imgStr2 = storyData.Character + storyData.State;
            if (storyData.Character + storyData.State != imgStr1)
            {
                _characterImgList[1].sprite =
                    GameManager.Resource.LoadSprite(_dialoguePath + storyData.Character + storyData.State);
                _characterColors.Add(imgStr2,new Color(1,1,1,0));
                break;
            }
        }

        foreach (var characterimg in _characterImgList)
        {
            if (characterimg.IsUnityNull()) throw new Exception("캐릭터 이미지가 없어용");
        }
    }
    private void InitBackgroundImg()
    {
        _backgroundImg.sprite = GameManager.Resource.LoadSprite(_dialoguePath + _storyDataList[0].Scene);
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
        ChangeTexts();
        ChangeCharacterImgColor();
    }

    private void ChangeTexts()
    {
        _nameText.text = _storyDataList[_currentIdx].Character;
        _typingEffect.StartTyping(_storyDataList[_currentIdx].Text);
    }

    private void ChangeCharacterImgColor()
    {
        string characterName = _storyDataList[_currentIdx].Character +_storyDataList[_currentIdx].State;
        
        _characterColors[characterName] = Color.white;

        foreach (var img in _characterImgList)
        {
            img.color = _characterColors[img.sprite.name];
        }
        if (_storyDataList[_currentIdx].Active == "false")
        {
            _characterColors[characterName] = Color.clear;
        }
        else
        {
            _characterColors[characterName] = new Color(1, 1, 1, 0.5f);
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
}