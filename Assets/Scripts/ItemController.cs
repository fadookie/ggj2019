using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

  public Button button;
  public Image Icon;
  public Text Name,Weight;
    // Start is called before the first frame update
    void Start()
    {
     button.onClick.AddListener(OpenInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OpenInfo() {
    Debug.Log("info is oppened for "+Name.text);
  }
}
