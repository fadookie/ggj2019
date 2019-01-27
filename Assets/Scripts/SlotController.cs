using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Model;
public class SlotController : MonoBehaviour
{
  [Tooltip("armor=0 weapon=1 shield=2 accessory=3")]
  public int type = ItemTypes.ARMOR;
  public Image itemImage;
  public Item Item { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public void setItem(Item item) {
    var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
    if (item.type == type)
    {
      itemImage.sprite = gameDataManager.itemSprites[item.sprite];
      Item = item;
    }
  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
