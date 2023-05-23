using System;
using UnityEngine;
using System.Collections.Generic;

public class PlatformerViewController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private Queue<UIView> _uiViews = new Queue<UIView>();

    private void Start()
    {
        playerData.Reliability.Value = 100;
    }
}