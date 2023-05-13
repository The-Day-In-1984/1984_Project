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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.reliability.Value -= 10;
        }
    }

    public void Down()
    {
        
    }
}