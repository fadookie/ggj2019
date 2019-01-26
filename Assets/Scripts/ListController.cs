using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{
  ArrayList Items;
  public GameObject itemPrefab;
  public Sprite testTexture;
  public GameObject content;

  public ListController() {
    Items = new ArrayList();
  }

    // Start is called before the first frame update
    void Start()
  {

    for (int i = 0; i < 10; i++) {
      GameObject item = Instantiate(itemPrefab) as GameObject;
      ItemController controller = item.GetComponent<ItemController>();
      controller.Icon.sprite = testTexture;
      controller.Name.text = "test"+i;
      controller.Weight.text = "weight" + i;
      controller.transform.SetParent(content.transform);
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
