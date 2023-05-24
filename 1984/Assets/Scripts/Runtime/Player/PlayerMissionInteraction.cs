using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMissionInteraction : MonoBehaviour
{
    private Collider2D nearestMissionObject;
    
    private const string MissionObjectTag = "MissionObject";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(MissionObjectTag))
        {
            nearestMissionObject = other;
            nearestMissionObject.GetComponent<MissionObject>().SetOutlineColor(Color.white);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == nearestMissionObject)
        {
            nearestMissionObject.GetComponent<MissionObject>().DisableOutline();
            nearestMissionObject = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(MissionObjectTag))
        {
            nearestMissionObject = other;
        }
    }

    private void Update()
    {
        if (nearestMissionObject != null && Input.GetKeyDown(KeyCode.E))
        {
            MissionInteraction();
        }
    }
    
    private async void MissionInteraction()
    {
        await nearestMissionObject.GetComponent<MissionObject>().Interact();
        nearestMissionObject = null;
    }
}
