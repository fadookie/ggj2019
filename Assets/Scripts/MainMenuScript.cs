using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

  public string GameScene;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PlayGame() {
    SfxPlayer.instance.PlaySound(SfxPlayer.Sound.Click);
    SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
  }

  public void QuitGame() {
    Debug.Log("quit game");
    SfxPlayer.instance.PlaySound(SfxPlayer.Sound.Click);
    Application.Quit();
  }
}
