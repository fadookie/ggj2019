using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryLoader : MonoBehaviour
{
    public bool Loaded { get; private set; }
  private bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    if (!pressed && Input.GetKeyDown(KeyCode.I))
    {
      pressed = true;
      SfxPlayer.instance.PlaySound(SfxPlayer.Sound.Click);
      if (Loaded)
        unloadUi();
      else
        loadUi();
    }
    else if (!Input.GetKeyDown(KeyCode.I))
      pressed = false;
        
    }

  public void loadUi() {
    Loaded = true;
    Time.timeScale = 0;
    SceneManager.LoadScene("Scenes/inventoryUi",LoadSceneMode.Additive);
  }

  public void unloadUi() {
    Loaded = false;
    Time.timeScale = 1;
    SceneManager.UnloadSceneAsync("inventoryUi");
  }
}
