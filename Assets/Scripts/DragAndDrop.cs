using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Model;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{

  public Item item;
  public GameObject itemObject;
  public bool justdown = false;
  public bool draggin = false;
  public bool onTrash;
  public SlotController slot;
  public Image dragImage;
  public ListController lc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    var gdm = GameObject.FindObjectOfType<GameDataManager>();
    if (Input.GetMouseButton(0))
    {
      Debug.Log("draggin");
      draggin = true;
      if (!justdown && item != null)
      {
        //set drag image icon here

        //-----
        justdown = true;
        dragImage.enabled = true;
        
      }
      dragImage.GetComponent<RectTransform>().position = Input.mousePosition;
    }
    else if (!Input.GetMouseButton(0)) {
      dragImage.enabled = false;
      draggin = false;
      
      if (slot != null && item != null )
      {

        if (slot.type == item.type)
        {
          //slot item
          if (slot.Item != null) {

            gdm.Player.Inventory.Add(slot.Item);
            lc.addItemToInventory(slot.Item);
          }
          slot.setItem(item);
          slotItem(gdm.Player, item);
          GameObject.Destroy(itemObject);
          removeFromInventory(gdm, item);
          item = null;
          itemObject = null;
          Debug.Log("slotted item");
        }
        else {
          //failed to slot play sound?
          item = null;
          itemObject = null;
        }
      }
      else if (item != null && onTrash)
      {
        //throw item on trash
        Debug.Log("trashed item");
        GameObject.Destroy(itemObject);
        removeFromInventory(gdm,item);

        item = null;
        itemObject = null;

      }
      else if (item != null) {
        //do nothing with item
        Debug.Log("did nothing with item");
      }
      justdown = false;
    }

    }


  public void slotItem(Player p,Item item)
  {
    switch (item.type) {
      case ItemTypes.ARMOR:
        p.Armor.SetValueAndForceNotify(item);
        break;
      case ItemTypes.WEAPON:
        p.PrimaryHand.SetValueAndForceNotify(item);
        break;
      case ItemTypes.SHIELD:
        p.Shield.SetValueAndForceNotify(item);
        break;
      case ItemTypes.ACCESSORY:
        p.Shield.SetValueAndForceNotify(item);
        break;

    }
  }


  public void removeFromInventory(GameDataManager gdm,Item item) {
    foreach (var i in gdm.Player.Inventory)
    {
      if (i == item)
      {
        gdm.Player.Inventory.Remove(i);
        break;
      }
    }
  }
}
