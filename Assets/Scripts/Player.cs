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
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

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
            rb.transform.localScale = Vector2.one;
            DOTween.Kill(rb.transform);
            handleAnimation();
        }
    }

    private void handleAnimation()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.transform.DOScaleY(landingScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        rb.transform.DOScaleX(landingScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}
