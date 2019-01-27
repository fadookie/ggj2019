using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Model;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    public Sprite[] itemSprites;
    public List<Item> AllItems;
    public Player Player;
    public Item CursorItem { get; set; }
    
    private int nextId;
    
    void Awake() {

        // Singleton setup;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        var reader = new Reader();
        var items = reader.read();
        AllItems = items;
        Player = new Player();
        CursorItem = null;
        Debug.Log("Loaded items:");
        items.ForEach(Debug.Log);

        Debug.Log(string.Format("Player: {0}", Player));
        
        PopulatePlayerInventory();
    }

    private void PopulatePlayerInventory() {
        for (var i = 0; i < 10; ++i) {
            Player.Inventory.Add(GenerateTestItem());
        }
        foreach (var slot in Player.AllItemSlots) {
            slot.Value = GenerateTestItem();
        }
    }

    public Item GenerateTestItem() {
        var item = new Item {
            Id = nextId,
            Name = $"Item {nextId}",
            Value = nextId,
            Weight = nextId,
            HpMod = nextId,
            MpMod = nextId,
            SpeedMod = nextId,
        };
        ++nextId;
        return item;
    }
}
