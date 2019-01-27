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
    public GameObject playerObject;
    public GameObject pickupPrefab;

  private float startTime;
  private float endTime;
    
    private int nextId;
    
    void Awake() {
    startTime = Time.time;
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
        Debug.Log("Loaded items:");
        items.ForEach(Debug.Log);

        Debug.Log(string.Format("Player: {0}", Player));
        
        PopulatePlayerInventory();
    Debug.Log("inventory weight = "+Player.getInventoryWeight());
      pickupPrefab.SetActive(false);
    }

  public void addPickup(Item item) {
    GameObject p = Instantiate(pickupPrefab);
    var pickup = p.GetComponent<ItemPickup>();
    pickup.itemID = item.Id;
    Vector3 pp = playerObject.transform.position;
    float range = 1;
    p.GetComponent<Transform>().position = new Vector3(pp.x + Random.Range(-range, range),pp.y + Random.Range(-range, range), pp.z);
    p.SetActive(true);
  }

    private void PopulatePlayerInventory() {
      for (var i = 0; i < 9; i++) {
       Player.Inventory.Add(AllItems.Where(it => it.Id == i+1).FirstOrDefault());
      }
        //for (var i = 0; i < 10; ++i)
        //{
        //  Player.Inventory.Add(GenerateTestItem());
        //}
      //for (var i = 0; i < 10; ++i) {
      //        Player.Inventory.Add(GenerateTestItem());
      //    }
      //    foreach (var slot in Player.AllItemSlots) {
      //        slot.Value = GenerateTestItem();
      //    }
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

  /// <summary>
  /// call when win condition is achieved
  /// </summary>
  public void endTimeCount() {
    endTime = Time.time;
  }

  /// <summary>
  /// gets the total time it too from start to finish - must have called endTimeCount when victory is triggered
  /// </summary>
  /// <returns></returns>
  public float totalTime() {
    return endTime - startTime;
  }
}
