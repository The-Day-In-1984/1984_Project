using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    // temp
    [SerializeField] private GameObject[] _platforms;

    /*
    private void OnEnable()
    {
        DisablePlatforms();
        EnableCurrentDayPlatforms();
        
        Debug.Log(GameManager.Instance.CurrentDay + "!!!!!!!!!!!!!!!!");
    }
    */
    
    private void DisablePlatforms()
    {
        foreach (var platform in _platforms)
        {
            platform.SetActive(false);
        }
    }
    
    private void EnableCurrentDayPlatforms()
    {
        _platforms[GameManager.Instance.CurrentDay].SetActive(true);
    }
}
