using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Model;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{

  public Item item;
  public bool draggin = false;
  public bool onTrash;
  public SlotController slot;
  public Image dragImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    var gdm = GameObject.FindObjectOfType<GameDataManager>();
    if (item != null && Input.GetMouseButton(0))
    {
      Debug.Log("draggin");
      draggin = true;
      dragImage.enabled = true;
      dragImage.GetComponent<RectTransform>().position = Input.mousePosition;
    }
    else if (!Input.GetMouseButton(0)) {
      dragImage.enabled = false;
      draggin = false;
      Debug.Log("not draggin");
      if (slot != null && item != null) {
        slot.Item = item;
        slot.itemImage.sprite = gdm.itemSprites[item.sprite];
        item = null;
      }
    }
    
    }
}
