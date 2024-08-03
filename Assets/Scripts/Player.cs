using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Speed Setup")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 2f;
    public Vector2 friction = new Vector2(0.1f, 0);

    [Header("Animation Setup")]
    public float jumpScaleX = 0.5f;
    public float jumpScaleY = 1.5f;
    public float landingScaleX = 1.5f;
    public float landingScaleY = 0.5f;
    public float animationDuration = 0.3f;

    [Header("Animator")]
    public Animator animator;
    public string boolRun = "Run";
    public string boolJumpUp = "JumpUp";
    public string boolJumpDown = "JumpDown";
    public string boolLanding = "Landing";

    private float _currentSpeed;
    private bool _isJumping = false;
    private int _currentDirection = 1;

    void Update()
    {
            
        handleMoviment();
        handleJump();
    }

    private void handleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = runSpeed;
        }
        else
        {
            _currentSpeed = walkSpeed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            animator.SetBool(boolRun, true);
            if (_currentSpeed == runSpeed) animator.speed = 2;
            if (rb.transform.localScale.x != 1) 
            {
                rb.transform.DOScaleX(1, 0.1f);
                _currentDirection = 1;
            } 

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            animator.SetBool(boolRun, true);
            if (_currentSpeed == runSpeed) animator.speed = 2;
            if (rb.transform.localScale.x != -1) 
            {
                rb.transform.DOScaleX(-1, 0.1f);
                _currentDirection = -1;
            }

        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (rb.velocity.x > 0)
        {
            rb.velocity -= friction;
            
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    private void handleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.transform.localScale = new Vector2(_currentDirection, 1);
            DOTween.Kill(rb.transform);
            handleAnimation();
            _isJumping = true;
            animator.SetBool(boolJumpUp, true);
        }
        if (rb.velocity.y > 0)
        {
            animator.SetBool(boolJumpUp, true);
            animator.SetBool(boolJumpDown, false);
        }
        else if (rb.velocity.y < 0)
        {
            animator.SetBool(boolJumpUp, false);
            animator.SetBool(boolJumpDown, true);
        } else
        {
            animator.SetBool(boolLanding, true);
        }
    }

    private void handleAnimation()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && _isJumping)
        {
            rb.transform.DOScaleY(landingScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
            rb.transform.DOScaleX(landingScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
            _isJumping = false;
        }
    }
}
