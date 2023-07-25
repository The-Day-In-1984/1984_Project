using Enums;
using UnityEngine;
using UnityEngine.UI;

public class TitleViewController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitButton;
    
    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
        loadButton.onClick.AddListener(OnLoadButtonClick);
        settingButton.onClick.AddListener(OnSettingButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }
    
    private void OnStartButtonClick()
    {
        GameManager.UI.ChangeState(GameState.Dialogue);
    }
    
    private void OnLoadButtonClick()
    {
        Debug.Log("Load");
    }
    
    private void OnSettingButtonClick()
    {
        GameManager.UI.PopupPush("UIView_Setting");
    }
    
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}