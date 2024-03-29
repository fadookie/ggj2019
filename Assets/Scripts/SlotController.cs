﻿using System.Collections;
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
        setItem(p.Weapon.Value);
        break;
      case ItemTypes.SHIELD:
        setItem(p.Shield.Value);
        break;
      case ItemTypes.ACCESSORY:
        setItem(p.Accessory.Value);
        break;

    }
  }

  public void setItem(Item item) {
    var gameDataManager = GameObject.FindObjectOfType<GameDataManager>();
    if (item != null && item.Type == type)
    {
      itemImage.sprite = gameDataManager.itemSprites[item.Art];
      Item = item;
    }
    else if (item == null) {
      itemImage.sprite = gameDataManager.noImage;
      Item = null;
      Player p = gameDataManager.Player;
      switch (type)
      {
        case ItemTypes.ARMOR:
          p.Armor.SetValueAndForceNotify(null);
          break;
        case ItemTypes.WEAPON:
          p.Weapon.SetValueAndForceNotify(null);
          break;
        case ItemTypes.SHIELD:
          p.Shield.SetValueAndForceNotify(null);
          break;
        case ItemTypes.ACCESSORY:
          p.Accessory.SetValueAndForceNotify(null);
          break;

      }
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
