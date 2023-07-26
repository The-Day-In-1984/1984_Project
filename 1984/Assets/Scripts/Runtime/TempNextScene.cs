using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TempNextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.UI.ChangeState(GameState.Dialogue);
    }
}
