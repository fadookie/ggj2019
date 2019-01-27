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

    public Sprite[] itemSprites;
    public List<Item> AllItems;
    public Player Player;
    public GameObject playerObject;
    public GameObject pickupPrefab;

    private int nextId;

    void Awake() {
        // Singleton setup;
        if (instance != null) {
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

        PopulatePlayerInventory();
        Debug.Log(string.Format("Populated Player: {0}", Player));
        Debug.Log("inventory weight = " + Player.Encumbrance.Value);
        pickupPrefab.SetActive(false);
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
}