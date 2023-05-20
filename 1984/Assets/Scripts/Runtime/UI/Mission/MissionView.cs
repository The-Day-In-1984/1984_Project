using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionView : UIView
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
        }
    }
}
