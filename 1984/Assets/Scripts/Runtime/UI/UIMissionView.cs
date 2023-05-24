using System;
using UnityEngine;
using DG.Tweening;
public class UIMissionView : UIView
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }
}
