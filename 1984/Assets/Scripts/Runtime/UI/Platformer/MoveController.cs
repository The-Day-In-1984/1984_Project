using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Movement movement;
    private float x;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump();
        }
        // long jump
        if (Input.GetKey(KeyCode.Space))
        {
            movement.isLongJump(true);

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement.isLongJump(false);
        }

    }

    private void FixedUpdate()
    {
        //move
        movement.Move(x);

    }
}
