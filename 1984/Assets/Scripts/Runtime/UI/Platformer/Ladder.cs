using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float handlerOffset = 0.3f;
    [SerializeField]private float nearCheckOffset = 0.15f;
    [HideInInspector] public bool isNearLadder;

    // positions for ladder climbing logic
    [HideInInspector] public float posX;
    [HideInInspector] public float posY;
    [HideInInspector] public float posBottomY;
    [HideInInspector] public float posTopHandlerY;
    [HideInInspector] public float posBottomHandlerY;
    [HideInInspector] public float posPlatformY;
    Bounds bounds;
    public float ladderMaxY, ladderMinY;


    void Awake()
    {
        // set up
        GetComponent<BoxCollider2D>().offset = Vector2.zero;
        Vector2 size = GetComponent<BoxCollider2D>().size;
        Transform ladderTop = transform.GetChild(0).transform;
        Transform ladderPlatform = transform.GetChild(1).transform;
        Transform ladderBottom = transform.GetChild(2).transform;
        ladderTop.position = new Vector3(transform.position.x, transform.position.y + (size.y / 2), 0);
        ladderBottom.position = new Vector3(transform.position.x, transform.position.y - (size.y / 2), 0);

        posX = transform.position.x;
        posY = transform.position.y;
        float posTopY = ladderTop.transform.position.y;
        posBottomY = ladderBottom.transform.position.y;
        posPlatformY = ladderPlatform.transform.position.y;
        posTopHandlerY = posTopY + handlerOffset;
        posBottomHandlerY = posBottomY + handlerOffset;

        bounds = GetComponent<BoxCollider2D>().bounds;
        ladderMaxY = bounds.max.y;
        ladderMinY = bounds.min.y;
    }
    /*

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //near the ladder
            isNearLadder = (other.gameObject.transform.position.x > (posX - nearCheckOffset) &&
        other.gameObject.transform.position.x < (posX + nearCheckOffset));
            other.gameObject.GetComponent<PlayerController>().ladder = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearLadder = false;
            other.gameObject.GetComponent<PlayerController>().ladder = null;
        }
    }
    */
}