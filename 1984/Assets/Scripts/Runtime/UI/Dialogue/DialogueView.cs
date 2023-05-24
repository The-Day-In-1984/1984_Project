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
    private readonly string _dialoguePath = "Dialogue/";

    private void Awake()
    {
        _characterImgList.Add(GameObject.Find("LeftCharacterImg").GetComponent<Image>());
        _characterImgList.Add(GameObject.Find("RightCharacterImg").GetComponent<Image>());
        _nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        _dialogueText = GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>();
        _optionPanel = GameObject.Find("OptionPanel");
        _optionGameObject = GameObject.Find("OptionButton");
        _backgroundImg = GameObject.Find("BackgroundImg").GetComponent<Image>();
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
        string img = _storyDataList[0].Character + _storyDataList[0].State;
        _characterImgList[0].sprite = GameManager.Resource.LoadSprite(_dialoguePath + img);
        foreach (var storyData in _storyDataList)
        {
            if (storyData.Character + storyData.State != img)
            {
                _characterImgList[1].sprite =
                    GameManager.Resource.LoadSprite(_dialoguePath + storyData.Character + storyData.State);
                break;
            }
        }

        foreach (var characterimg in _characterImgList)
        {
            if (characterimg.IsUnityNull()) throw new Exception("캐릭터 이미지가 없어용");
        }

        foreach (var cImg in _characterImgList)
            cImg.color = new Color(1, 1, 1, 0.5f);
    }
    private void InitBackgroundImg()
    {
        _backgroundImg.sprite = GameManager.Resource.LoadSprite(_dialoguePath + _storyDataList[0].Scene);
    }

    public void Run()
    {
        if (_state == state.option) return;
        ChangeDialogue();
        if (IsFinishDialogue())
        {
            Hide();
            return;
        }

        switch (_storyDataList[_currentIdx].Type)
        {
            case "Dialogue":
                ShowDialogue();
                break;
            case "Option":
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
            GotoId(_storyDataList[_currentIdx].Goto);
            ChangeDialogue();
        }
        else
            ++_currentIdx;
    }

    private void ShowDialogue()
    {
        _state = state.dialogue;
        ChangeTexts();
        ChangeFocusCharacterImg();
    }

    private void ChangeTexts()
    {
        _nameText.text = _storyDataList[_currentIdx].Character;
        _dialogueText.text = _storyDataList[_currentIdx].Text;
    }

    private void ChangeFocusCharacterImg()
    {
        foreach (var img in _characterImgList)
        {
            if (img.sprite.name == _storyDataList[_currentIdx].Character + _storyDataList[_currentIdx].State)
                img.color = new Color(1, 1, 1, 1f);
            else
                img.color = new Color(1, 1, 1, 0.5f);
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
        optionObj.GetComponent<Button>().onClick.AddListener(() => SelectOption(_storyDataList[idx].Goto));
        optionObj.GetComponentInChildren<TextMeshProUGUI>().text = _storyDataList[idx].Text;
        optionObj.SetActive(true);
    }
    private int GetOptionCount()
    {
        return _storyDataList.Count - _currentIdx;
    }
    private void SelectOption(string id)
    {
        GotoId(id);
        ChangeDialogue();
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