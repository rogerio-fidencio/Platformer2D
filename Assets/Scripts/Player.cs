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

    [Header("Animator")]
    public Animator animator;
    public string boolRun = "Run";
    public string boolJumpUp = "JumpUp";
    public string boolJumpDown = "JumpDown";
    public string boolLanding = "Landing";

    private float _currentSpeed;

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
}
