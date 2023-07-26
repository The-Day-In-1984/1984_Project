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
        if (GameManager.Instance.CurrentDay == 0)
        {
            LoadingSceneManager.LoadScene("Game_Platformer","DAY 1", "원스턴의 집");
        }
        else if (GameManager.Instance.CurrentDay == 1)
        {
            LoadingSceneManager.LoadScene("Game_Platformer","DAY 2", "파슨스의 집");
        }
    }

    public void OnExit()
    {
       
    }
}

public class DialogueState : IUIState
{
    public void OnEnter()
    {

        Debug.Log("여기 테스트!" + GameManager.Instance.CurrentDay);
        
        if (GameManager.Instance.CurrentDay == 1)
        {
            LoadingSceneManager.LoadScene("Game_End", "","");
            return;
        }
        
        LoadingSceneManager.LoadScene("Game_Dialogue", "","");

        
    }

    public void OnExit()
    {
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
