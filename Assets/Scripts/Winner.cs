using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
  [SerializeField] private AudioSource winnerSFX;
  private bool hasPlayed = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!hasPlayed && other.gameObject.tag == "Player" && winnerSFX != null)
    {
      winnerSFX.Play();
      hasPlayed = true;
    }
  }
}
