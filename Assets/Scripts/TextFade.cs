using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFade : MonoBehaviour
{
  TextMeshProUGUI[] childTexts;

  private void Start()
  {
    childTexts = GetComponentsInChildren<TextMeshProUGUI>();
    foreach (TextMeshProUGUI text in childTexts)
    {
      text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
  }

  public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
  {
    i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    while (i.color.a < 1.0f)
    {
      i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
      yield return null;
    }
  }

  public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
  {
    i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
    while (i.color.a > 0.0f)
    {
      i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
      yield return null;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      TextMeshProUGUI[] childTexts = GetComponentsInChildren<TextMeshProUGUI>();
      foreach (TextMeshProUGUI text in childTexts)
      {
        if (text.color.a == 0)
          StartCoroutine(FadeTextToFullAlpha(1f, text));
      }
    }
  }
}
