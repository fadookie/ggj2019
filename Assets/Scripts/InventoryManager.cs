using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        var reader = new Reader();
        reader.read();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
