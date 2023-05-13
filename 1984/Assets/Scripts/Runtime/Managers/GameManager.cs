using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { Init(); return _instance; } }

    //private readonly InputManager _input = new InputManager();
    private readonly ResourceManager _resource = new ResourceManager();
    private readonly DataManager _data = new DataManager();
    private readonly SoundManager _sound = new SoundManager();
    private readonly UIManager _ui = new UIManager();

    //public static InputManager Input => _instance._input;
    public static ResourceManager Resource => _instance._resource;
    public static DataManager Data => _instance._data;
    public static SoundManager Sound => _instance._sound;
    public static UIManager UI => _instance._ui;
    
    public int CurrentDay
    {
        get { return currentday;}
        set { Mathf.Clamp(value, 0, 14); }
    }

    private int currentday;
    
    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if (go == null)
            {
                go = new GameObject { name = "@GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<GameManager>();
            
            // 추가적인 매니저 초기화
            _instance._data.Init();
            _instance._ui.Init();
        }
    }

    private void Start()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Init();
    }

    private void Update()
    {
        //temp
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (SceneManager.GetActiveScene().name == "Game_Title")
            {
                
                GameManager.UI.ChangeState(GameState.Platformer);
            }
            else if (SceneManager.GetActiveScene().name == "Game_Platformer")
            {
                
                GameManager.UI.ChangeState(GameState.Dialogue);
            }
            else
            {
                
                GameManager.UI.ChangeState(GameState.Ttitle);
            }
        }
    }

    public void Clear()
    {
        
    }
}
