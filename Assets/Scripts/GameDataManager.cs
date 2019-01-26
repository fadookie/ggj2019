using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Model;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public List<Item> AllItems;
    public Player Player;
    
    // Start is called before the first frame update
    void Start() {
        var reader = new Reader();
        var items = reader.read();
        AllItems = items;
        
        Player = new Player();

        Debug.Log("Loaded items:");
        items.ForEach(Debug.Log);

        Debug.Log(string.Format("Player: {0}", Player));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
