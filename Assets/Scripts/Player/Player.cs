using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SOPlayerSetup soPlayerSetup;

    [Header("Jump Colision Check")]
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private float spaceToGround = 0.1f;
    [SerializeField] private ParticleSystem jumpEffect;
    private float distanceToGround;

    private float _currentSpeed;

    private Animator _currentAnimator;

    private void Awake()
    {
        _currentAnimator = Instantiate(soPlayerSetup.animator, rb.transform);
        if (collider2D != null) 
        {
            distanceToGround = collider2D.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + spaceToGround);
    }

    void Update()
    {
        handleMoviment();
        handleJump();
    }

    private void handleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.runSpeed;
        }
        else
        {
            _currentSpeed = soPlayerSetup.walkSpeed;
            _currentAnimator.speed = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            _currentAnimator.SetBool(soPlayerSetup.boolRun, true);
            if (_currentSpeed == soPlayerSetup.runSpeed) _currentAnimator.speed = 2;
            if (rb.transform.localScale.x != 1) 
            {
                rb.transform.DOScaleX(1, 0.1f);
            } 

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            _currentAnimator.SetBool(soPlayerSetup.boolRun, true);
            if (_currentSpeed == soPlayerSetup.runSpeed) _currentAnimator.speed = 2;
            if (rb.transform.localScale.x != -1) 
            {
                rb.transform.DOScaleX(-1, 0.1f);
            }

        }
        else
        {
            _currentAnimator.SetBool(soPlayerSetup.boolRun, false);
        }

        if (rb.velocity.x > 0)
        {
            rb.velocity -= soPlayerSetup.friction;
            
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += soPlayerSetup.friction;
        }
    }

    private void handleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, soPlayerSetup.jumpForce);
            PlayJumpVFX();
            _currentAnimator.SetBool(soPlayerSetup.boolJumpUp, true);
        }
        if (rb.velocity.y > 0)
        {
            _currentAnimator.SetBool(soPlayerSetup.boolJumpUp, true);
            _currentAnimator.SetBool(soPlayerSetup.boolJumpDown, false);
        }
        else if (rb.velocity.y < 0)
        {
            _currentAnimator.SetBool(soPlayerSetup.boolJumpUp, false);
            _currentAnimator.SetBool(soPlayerSetup.boolJumpDown, true);
        } else
        {
            _currentAnimator.SetBool(soPlayerSetup.boolLanding, true);
        }
    }

    private void PlayJumpVFX()
    {
        if (jumpEffect != null) jumpEffect.Play();
    }
}
