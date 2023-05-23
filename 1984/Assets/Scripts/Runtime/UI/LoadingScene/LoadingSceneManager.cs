using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    public static string TitleText;
    public static string LoadingText;
 
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI TitleTextGUI;
    [SerializeField] private TextMeshProUGUI LoadingTextGUI;
 
    private void Start()
    {
        StartCoroutine(LoadScene());
        SetText();
    }
    
    // 데이터베이스로 교체
    public static void LoadScene(string sceneName, string titleText, string loadingText)
    {
        nextScene = sceneName;
        TitleText = titleText;
        LoadingText = loadingText;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;
 
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        
        op.allowSceneActivation = false;
        
        float timer = 0.0f;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        
        timer = 0.0f;
        
        while (!op.isDone)
        {
            yield return null;
 
            timer += Time.deltaTime;
 
            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
 
                if (progressBar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
    
    private void SetText()
    {
        TitleTextGUI.text = TitleText;
        LoadingTextGUI.text = LoadingText;
    }
}
