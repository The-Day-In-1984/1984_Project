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
    
    public override void Show()
    {
        base.Show();
        GameManager.Data.IsMission = true;
    }
    
    public override void Hide()
    {
        base.Hide();
        GameManager.Data.IsMission = false;
    }
}
