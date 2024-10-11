using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/PlayerSetup")]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Moviment")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public Vector2 friction = new Vector2(0.1f, 0);

    [Header("Animator")]
    public string boolRun = "Run";
    public string boolJumpUp = "JumpUp";
    public string boolJumpDown = "JumpDown";
    public string boolLanding = "Landing";
    public Animator animator;
}
