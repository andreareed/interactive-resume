using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D rb;
  private BoxCollider2D boxCollider;
  private Animator animator;
  private SpriteRenderer spriteRenderer;

  [SerializeField] private Joystick joystick;
  [SerializeField] private float moveSpeed = 7f;
  [SerializeField] private float jumpForce = 14f;
  [SerializeField] private AudioSource jumpSFX;

  private enum MovementState { idle, running, jumping, falling };
  private float x = 0;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    boxCollider = GetComponent<BoxCollider2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    bool jumpInput = Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0;
    if (jumpInput)
    {
      Jump();
    }

    UpdateAnimationState();
  }

  public void Jump()
  {
    if (IsGrounded())
    {
      if (!jumpSFX.isPlaying && !SoundManager.Instance.isMuted)
      {
        jumpSFX.Play();
      }
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
  }

  void FixedUpdate()
  {
    x = Mathf.Abs(joystick.Horizontal) > .2 ? joystick.Horizontal : Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
  }

  private void UpdateAnimationState()
  {
    MovementState state;

    if (x != 0)
    {
      state = MovementState.running;
    }
    else
    {
      state = MovementState.idle;
    }

    if (rb.velocity.y > .2f)
    {
      state = MovementState.jumping;
    }
    else if (rb.velocity.y < -.1f)
    {
      state = MovementState.falling;
    }

    spriteRenderer.flipX = x != 0 ? x < 0 : spriteRenderer.flipX;
    animator.SetInteger("state", (int)state);
  }

  private bool IsGrounded()
  {
    return Physics2D.BoxCast(
      boxCollider.bounds.center,
      boxCollider.bounds.size,
      0f,
      Vector2.down,
      .1f,
      LayerMask.GetMask("Ground")
      );
  }
}
