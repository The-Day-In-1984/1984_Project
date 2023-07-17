using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescreenEyes : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float eyeRange = 0.5f;
    private float pos;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pos = transform.position.x;
    }


    void Update()
    {
        eyeFollow();
    }

    void eyeFollow()
    {
        float targetX = Mathf.Clamp(player.transform.position.x, pos - eyeRange, pos + eyeRange);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}



    

