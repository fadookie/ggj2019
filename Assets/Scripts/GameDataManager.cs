using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Model;
using UniRx;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    public Sprite noImage;
    public Sprite[] itemSprites;
    public List<Item> AllItems;
    public int AllItemsWeight { get; private set; }
    public int AllItemsValue { get; private set; }
    public Player Player;
    public GameObject playerObject;
    public GameObject pickupPrefab;
    private float startTime;
    private float endTime;
    private int nextId;
    public AnimationCurve weightBurdenCurve;

    void Awake() {
        startTime = Time.time;
        // Singleton setup;
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;

        var reader = new Reader();
        var items = reader.read();
        AllItems = items;
        AllItemsWeight = AllItems.Aggregate(0, (acc, next) => acc + next.Weight);
        AllItemsValue = AllItems.Aggregate(0, (acc, next) => acc + next.Value);
        Player = new Player();
        Debug.Log("Loaded items:");
        items.ForEach(Debug.Log);

        PopulatePlayerInventory();
        Debug.Log(string.Format("Populated Player: {0}", Player));
        Debug.Log($"inventory weight = {Player.InventoryWeight.Value}");
    }

    public float GetPlayerTunedWeightBurden(int inventoryWeight) {
        return weightBurdenCurve.Evaluate(inventoryWeight / (float)AllItemsWeight);
    }

    public void addPickup(Item item) {
        GameObject p = Instantiate(pickupPrefab);
        var pickup = p.GetComponent<ItemPickup>();
        pickup.itemID = item.Id;
        Vector3 pp = playerObject.transform.position;
        float range = 1;
        p.GetComponent<Transform>().position =
            new Vector3(pp.x + Random.Range(-range, range), pp.y + Random.Range(-range, range), pp.z);
        p.SetActive(true);
    }

    private void PopulatePlayerInventory() {
        Player.Armor.Value = AllItems.First(x => x.Type == ItemTypes.ARMOR);
        Player.Weapon.Value = AllItems.First(x => x.Type == ItemTypes.WEAPON);
        Player.Shield.Value = AllItems.First(x => x.Type == ItemTypes.SHIELD);
        Player.Accessory.Value = AllItems.First(x => x.Type == ItemTypes.ACCESSORY);
        var equippedItems = Player.AllItemSlots.Select(x => x.Value);
        AllItems.Where(x => !equippedItems.Contains(x)).ToList().ForEach(Player.Inventory.Add);
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