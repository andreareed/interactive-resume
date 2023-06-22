using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  static SoundManager instance;

  [SerializeField] private GameObject soundOn;
  [SerializeField] private GameObject soundOff;
  private AudioSource backgroundMusic;

  public static SoundManager Instance => instance;
  public bool isMuted = true;


  private void Awake()
  {
    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      instance = this;
    }
  }

  private void Start()
  {
    backgroundMusic = GetComponent<AudioSource>();
  }

  public void ToggleSound()
  {
    isMuted = !isMuted;
    soundOn.SetActive(!isMuted);
    soundOff.SetActive(isMuted);

    backgroundMusic.mute = isMuted;
  }
}
