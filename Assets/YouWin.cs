using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    void Start()
    {
        var gdm = FindObjectOfType<GameDataManager>();
        int value = gdm.AllItemsValue;
        UnityEngine.UI.Text valueText = transform.Find("Value").GetComponent<UnityEngine.UI.Text>();
        valueText.text = value.ToString() + " Gold";
    }

    void Update()
    {
        
    }
}
