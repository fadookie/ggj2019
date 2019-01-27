using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  public void OnPointerEnter(PointerEventData eventData)
  {
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    dnd.onTrash = true;
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    var dnd = GameObject.FindObjectOfType<DragAndDrop>();
    dnd.onTrash = false;
  }

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
