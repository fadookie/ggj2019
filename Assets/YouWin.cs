using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    void Start()
    {
        var gdm = GameDataManager.instance;
        if (gdm == null)
        {
            Debug.LogError("Missing GameDataManager in scene.");
        }

        long value = gdm.Player.GetCombinedValueOfItems();
        UnityEngine.UI.Text valueText = transform.Find("Value").GetComponent<UnityEngine.UI.Text>();
        valueText.text = "Gold value : \n" + value.ToString();
    }

    void Update()
    {
        
    }
}
