using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    CapsuleCollider2D box2d;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float jumpSpeed = 13.0f;
    [SerializeField] private float climbSpeed = 4.0f;
    private float keyHorizontal;
    private float keyVertical;
    private bool keyJump;

    [Header("Ladder")]
    private float transformY;
    private float transformHY;
    private bool isClimbingDown;
    private bool atLaddersEnd;
    private bool hasStartedClimbing;
    private bool startedClimbTransition;
    private bool finishedClimbTransition;
    [HideInInspector] public Ladder ladder;
    [SerializeField] private float climberHeight = 1.0f;

    private bool isGrounded;
    private bool isJumping;
    private bool isClimbing;
    private bool freezeInput;


    private void Awake()
    {
        box2d = GetComponent<CapsuleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGroundedStatus();
    }

    void Update()
    {
        PlayerDirectionInput();
        PlayerJumpInput();
        PlayerMovement();
    }

    private void CheckGroundedStatus()
    {
        isGrounded = false;

        Bounds bounds = box2d.bounds;
        Vector3 footPosition = new Vector2(bounds.center.x, bounds.min.y);

        if (Physics2D.OverlapCircle(footPosition, 0.1f, LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    private void PlayerDirectionInput()
    {
        if (!freezeInput)
        {
            keyHorizontal = Input.GetAxisRaw("Horizontal");
            keyVertical = Input.GetAxisRaw("Vertical");
        }
    }

    private void PlayerJumpInput()
    {
        if (!freezeInput)
        {
            keyJump = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void PlayerMovement()
    {
        transformY = transform.position.y;
        transformHY = transformY + climberHeight;

        //climbing part
        if (isClimbing)
        {
            Debug.DrawLine(new Vector3(ladder.posX - 2f, ladder.posTopHandlerY, 0),
                new Vector3(ladder.posX + 2f, ladder.posTopHandlerY, 0), Color.blue);
            Debug.DrawLine(new Vector3(ladder.posX - 2f, ladder.posBottomHandlerY, 0),
                new Vector3(ladder.posX + 2f, ladder.posBottomHandlerY, 0), Color.blue);
            Debug.DrawLine(new Vector3(transform.position.x - 2f, transformHY, 0),
                new Vector3(transform.position.x + 2f, transformHY, 0), Color.magenta);

            //climb to the top of the ladder
            if (transformHY > ladder.posTopHandlerY)
            {
                if (!isClimbingDown)
                {
                    if (!startedClimbTransition)
                    {
                        //start climb transition 
                        startedClimbTransition = true;
                        ClimbTransition(true);
                    }
                    else if (finishedClimbTransition)
                    {
                        // climb transition has finished and reposition character
                        finishedClimbTransition = false;
                        isJumping = false;

                        transform.position = new Vector2(ladder.posX, ladder.posPlatformY + 0.005f);

                        // at the top of the ladder
                        if (!atLaddersEnd)
                        {
                            //reset climbing
                            atLaddersEnd = true;
                            Invoke("ResetClimbing", 0.1f);
                        }
                    }
                }
            }
            // climbing down and haven't touched the ground (short ladder)
            else if (transformHY < ladder.posBottomHandlerY)
            {
                ResetClimbing();
            }
            else
            {
                if (!isClimbingDown)
                {
                    // jump off the ladder
                    if (keyJump && keyVertical == 0)
                    {
                        ResetClimbing();
                    }
                    // reached the ground by climbing down
                    else if (isGrounded && !hasStartedClimbing)
                    {
                        isJumping = false;

                        // climb transition has finished and reposition character
                        transform.position = new Vector2(ladder.posX, ladder.posBottomY + climberHeight);

                        // at the bottom of the ladder
                        if (!atLaddersEnd)
                        {
                            // reset climbing
                            atLaddersEnd = true;
                            Invoke("ResetClimbing", 0.1f);
                        }
                    }
                    //climbing
                    else if (keyVertical != 0)
                    {
                        // apply the direction and climb speed to our position
                        Vector3 climbDirection = new Vector3(0, climbSpeed) * keyVertical;
                        transform.position = transform.position + climbDirection * Time.deltaTime;
                    }
                }
            }
        }
        // not climbing part
        else
        {
            //moving left
            if (keyHorizontal < 0)
            {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            }
            //moving right
            else if (keyHorizontal > 0)
            {
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            }
            else// no movement
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            }

            //jump
            if (keyJump && isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
            if (!isGrounded)
            {
                isJumping = true;
            }

            // start climbing
            if (ladder != null)
            {
                // climbing up
                if (ladder.isNearLadder && keyVertical > 0 && transformHY < ladder.posTopHandlerY)
                {
                    isClimbing = true;
                    isClimbingDown = false;
                    rb2d.bodyType = RigidbodyType2D.Kinematic;
                    rb2d.velocity = Vector2.zero;
                    transform.position = new Vector3(ladder.posX, transformY + 0.025f, 0);
                    StartedClimbing();
                }
                // climbing down
                if (ladder.isNearLadder && keyVertical < 0 && isGrounded && transformHY > ladder.posTopHandlerY)
                {
                    isClimbing = true;
                    isClimbingDown = true;
                    rb2d.bodyType = RigidbodyType2D.Kinematic;
                    rb2d.velocity = Vector2.zero;
                    transform.position = new Vector3(ladder.posX, transformY, 0);
                    ClimbTransition(false);
                }
            }
        }
    }

    private void StartedClimbing()
    {
        StartCoroutine(StartedClimbingCo());
    }

    private IEnumerator StartedClimbingCo()
    {
        hasStartedClimbing = true;
        yield return new WaitForSeconds(0.1f);
        hasStartedClimbing = false;
    }

    // reset climbing variables and rigidbody type
    private void ResetClimbing()
    {
        if (isClimbing)
        {
            isClimbing = false;
            atLaddersEnd = false;
            startedClimbTransition = false;
            finishedClimbTransition = false;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = Vector2.zero;
        }
    }

    private void ClimbTransition(bool movingUp)
    {
        StartCoroutine(ClimbTransitionCo(movingUp));
    }


    private IEnumerator ClimbTransitionCo(bool movingUp)
    {
        // block input during transition
        FreezeInput(true);

        finishedClimbTransition = false;
        Vector3 newPos = Vector3.zero;

        if (movingUp)
        {
            // moving up transition
            newPos = new Vector3(ladder.posX, transformY + ladder.handlerOffset, 0);
        }
        else
        {
            // moving down transition
            transform.position = new Vector3(ladder.posX, ladder.posTopHandlerY - climberHeight + ladder.handlerOffset, 0);
            newPos = new Vector3(ladder.posX, ladder.posTopHandlerY - climberHeight, 0);
        }

        while (transform.position != newPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, climbSpeed * Time.deltaTime);
            yield return null;
        }

        isClimbingDown = false;
        finishedClimbTransition = true;
        FreezeInput(false);
    }

    //freezing input for transition
    private void FreezeInput(bool isFreezeInput)
    {
        freezeInput = isFreezeInput;
    }
}