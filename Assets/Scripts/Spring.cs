using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
  private Animator animator;
  private AudioSource audioSource;
  [SerializeField] private float springForce = 20f;

  [SerializeField] private AudioClip springSFX;

  void Start()
  {
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {

    Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
      rb.velocity = new Vector2(rb.velocity.x, springForce);
      if (springSFX != null)
      {
        audioSource.PlayOneShot(springSFX);
      }
      if (animator != null)
      {
        animator.SetTrigger("spring");
      }
    }
  }
}
