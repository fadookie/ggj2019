using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Model;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
  [Tooltip("armor=0 weapon=1 shield=2 accessory=3")]
  public int type = ItemTypes.ARMOR;
  public Image itemImage;
  public Item Item { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
     var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
    Player p = gameDataManager.Player;
    switch (type)
    {
      case ItemTypes.ARMOR:
        setItem(p.Armor.Value);
        break;
      case ItemTypes.WEAPON:
        setItem(p.PrimaryHand.Value);
        break;
      case ItemTypes.SHIELD:
        setItem(p.Shield.Value);
        break;
      case ItemTypes.ACCESSORY:
        setItem(p.Accessory1.Value);
        break;

    }
  }

  public void setItem(Item item) {
    var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
    if (item != null && item.type == type)
    {
      itemImage.sprite = gameDataManager.itemSprites[item.sprite];
      Item = item;
    }
  }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void OnPointerEnter(PointerEventData eventData)
  {
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    dnd.slot = this;
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    dnd.slot = null;
  }
}
