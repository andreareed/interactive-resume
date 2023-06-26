using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeAtPosition : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI text;
  [SerializeField] private Image icon;
  [SerializeField] private Transform player;
  [SerializeField] private float enterXPosition;
  [SerializeField] private float exitXPosition;

  private bool fadingIn = false;
  private bool fadingOut = false;

  void Update()
  {
    bool inFadeZone = player.position.x > enterXPosition && player.position.x < exitXPosition;

    if (!fadingIn && inFadeZone && text.color.a < 1)
    {
      StartCoroutine(FadeTextToFullAlpha(.5f));
    }
    else if (!fadingOut && !inFadeZone && text.color.a > 0)
    {
      StartCoroutine(FadeTextToZeroAlpha(.1f));
    }
  }

  public IEnumerator FadeTextToFullAlpha(float t)
  {
    fadingIn = true;
    fadingOut = false;
    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 0);
    while (text.color.a < 1.0f)
    {
      text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
      icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, icon.color.a + (Time.deltaTime / t));
      yield return null;
    }
  }

  public IEnumerator FadeTextToZeroAlpha(float t)
  {
    fadingOut = true;
    fadingIn = false;
    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 1);
    while (text.color.a > 0.0f)
    {
      text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
      icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, icon.color.a - (Time.deltaTime / t));
      yield return null;
    }
  }
}
