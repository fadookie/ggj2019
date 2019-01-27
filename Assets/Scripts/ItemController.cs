using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Data.Model;

public class ItemController : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

  public GameObject self;
  public Button button;
  public Image Icon;
  public Text Name,Weight;
  public Item item;
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

  public void OnPointerEnter(PointerEventData eventData)
  {

    
    Debug.Log("inside "+Name.text);
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    if (!dnd.draggin)
    {
      dnd.item = item;
      dnd.itemObject = self;
    }
    else {

    }
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    if (!dnd.draggin)
    {

      dnd.item = null;
      dnd.itemObject = null;
    }
    else {

    }

  }
}
