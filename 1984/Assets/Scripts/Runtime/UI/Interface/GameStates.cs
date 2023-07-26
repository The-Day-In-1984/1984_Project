using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleState : IUIState
{
    public async void OnEnter()
    {
        LoadingSceneManager.LoadScene("Game_Title", "INTRO", "1984년, 유라시아 정보원");
    }

    public void OnExit()
    {
       
    }
}

public class PlatformerState : IUIState
{
    public async void OnEnter()
    {
        LoadingSceneManager.LoadScene("Game_Platformer","DAY 1", "원스턴의 집");
    }

    public void OnExit()
    {
       
    }
}

public class DialogueState : IUIState
{
    public void OnEnter()
    {
        LoadingSceneManager.LoadScene("Game_Dialogue", "","");
    }

    public void OnExit()
    {
       GameManager.Instance.CurrentDay++;
    }
}

public class EndState : IUIState
{
    public void OnEnter()
    {
        Debug.Log("EndState OnEnter");
    }

    public void OnExit()
    {
       
    }
}
