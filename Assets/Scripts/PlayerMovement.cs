using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    // start jumping

    [SerializeField]
    private float jumpMultiplier = 1;
    
    [SerializeField]
    private float jumpFrequency = 0.2f;

    [SerializeField]
    private Transform groundCheckTransform;

    [SerializeField]
    private float groundCheckRadius;

    [SerializeField]
    private LayerMask groundCheckLayer;
    private Rigidbody2D rigid;
    private float nextJumpTime;
    private bool isGrounded;

    // end jumping

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerSoundController playerSoundController;

    [SerializeField]
    private float movementSpeed = 1;
    
    [SerializeField]
    private float movementMultipiler = 1.01f;
    public bool canMove;

    [SerializeField]
    private float fallMultiplier = 1;

    void Start()
    {
        isGrounded = true;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKeyDown(KeyCode.Space) 
        onGroundCheck();
        if(Input.touchCount > 0 &&isGrounded && (nextJumpTime < Time.timeSinceLevelLoad) && canMove)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            { 
                rigid.angularVelocity = 0;
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                jump();
                nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) &&isGrounded && (nextJumpTime <= Time.timeSinceLevelLoad) && canMove)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            { 
                rigid.angularVelocity = 0;
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                jump();
                nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            }
        }
        
        gravityEffect();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            rigid.velocity = new Vector2(movementSpeed, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }
    }

    private void jump()
    {
        rigid.AddForce(new Vector2(0f, jumpMultiplier));
        playerSoundController.playJumpSound();
    }

    private void onGroundCheck()
    {
        bool lastGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundCheckLayer);
        animator.SetBool("Jump",!isGrounded);
        if(lastGrounded == false && isGrounded == true)
        {
            playerSoundController.playLandingSound();
        }
    }

    private void gravityEffect()
    {
        if(rigid.velocity.y < 0)
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void runFaster()
    {
        movementSpeed *= movementMultipiler;
    }
}
