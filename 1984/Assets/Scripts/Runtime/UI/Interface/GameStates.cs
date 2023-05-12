using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleState : IUIState
{
    public void OnEnter()
    {
        SceneManager.LoadScene("Game_Title");
        //Debug.Log("MainState OnEnter");
        
        var titleUI = GameManager.UI.GetUIView("UIView_Title");
    }

    public void OnExit()
    {
       
    }
}

public class PlatformerState : IUIState
{
    public void OnEnter()
    {
        SceneManager.LoadScene("Game_Platformer");
        Debug.Log("PlatformerState OnEnter");
    }

    public void OnExit()
    {
       
    }
}

public class DialogueState : IUIState
{
    public void OnEnter()
    {
        SceneManager.LoadScene("Game_Dialogue");
        Debug.Log("DialogueState OnEnter");
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
