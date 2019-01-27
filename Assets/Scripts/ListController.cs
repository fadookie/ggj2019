using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Model;

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

  public void addItemToInventory(Item item) {
    var gdm = GameObject.FindObjectOfType<GameDataManager>();
    GameObject i = Instantiate(itemPrefab) as GameObject;
    i.SetActive(true);
    ItemController controller = i.GetComponent<ItemController>();
    controller.Icon.sprite = gdm.itemSprites[item.Art];
    controller.Name.text = item.Name;
    controller.Weight.text = "weight" + item.Weight;
    controller.item = item;
    controller.transform.SetParent(content.transform);
    Debug.Log("item added to inventory");
  }

    // Start is called before the first frame update
    void Start()
    {
        var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
        foreach (var item in gameDataManager.Player.Inventory) {
          addItemToInventory(item);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
