using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextScript : MonoBehaviour
{
  public Text text;
  private bool showing = false;
  private float elapsed;
  private float duration = 3.5f;

  public void showText(string text) {
    this.text.text = text;
    gameObject.SetActive(true);
    elapsed = 0;
    showing = true;
  }
    // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if (showing) {
        elapsed += Time.unscaledDeltaTime; ;
        if (elapsed >= duration) {
          elapsed = 0;
          showing = false;
          gameObject.SetActive(false);
        }
      }
    }
}
