using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
  private Animator animator;
  [SerializeField] private float springForce = 20f;

  [SerializeField] private AudioSource springSFX;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {

    Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
      rb.velocity = new Vector2(rb.velocity.x, springForce);
      if (springSFX != null)
      {
        springSFX.Play();
      }
      if (animator != null)
      {
        animator.SetTrigger("spring");
      }
    }
  }
}
