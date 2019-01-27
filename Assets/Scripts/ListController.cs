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
  public GameObject trash;

  public ListController() {
    Items = new ArrayList();
  }

    // Start is called before the first frame update
    void Start()
  {
    var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
    foreach (var item in gameDataManager.AllItems) {
      GameObject i = Instantiate(itemPrefab) as GameObject;
      ItemController controller = i.GetComponent<ItemController>();
      controller.Icon.sprite = testTexture;
      controller.Name.text = item.Name;
      controller.Weight.text = "weight" + item.Weight;
      controller.item = item;
      controller.transform.SetParent(content.transform);
    }

    itemPrefab.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
