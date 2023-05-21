using System;
using System.Collections;
using UnityEngine;

public class TriggerTimeMission : TimeMission
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StartCount();
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StopCount();
        }
    }
}
