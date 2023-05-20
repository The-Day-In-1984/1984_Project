using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleState : IUIState
{
    public async void OnEnter()
    {
        SceneManager.LoadScene("Game_Title");

        var loading = GameManager.UI.GetUIView("UIView_Loading");
        loading.GetComponent<LoadingView>().SetLoadingText("로딩중", "로딩중입니다.");
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
        
        var loading = GameManager.UI.GetUIView("UIView_Loading");
        loading.GetComponent<LoadingView>().SetLoadingText("로딩중", "로딩중입니다.");
        //Debug.Log("PlatformerState OnEnter");
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
        //Debug.Log("DialogueState OnEnter");
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
