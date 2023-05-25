using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TempNextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // 잠시만 자리좀 빌리겠습니다..
        GameManager.Data._curDialogueId = "1";
        GameManager.UI.ChangeState(GameState.Dialogue);
    }
}
