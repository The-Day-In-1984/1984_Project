using System;
using UnityEngine;

public class PlatformerViewController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private void Start()
    {
        playerData.reliability.Value = 100;
    }

    private void Update()
    {
        //temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.reliability.Value -= 10;
        }
    }
}