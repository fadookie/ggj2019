using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Model;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TempInventoryTester : MonoBehaviour
{
    public Button AddItem;
    public Button DropItem;
    public Button ChangeEquipment;
    public Text PlayerInfo;
    public Text InventoryInfo;
    public Text AllItemsInfo;

    string ToDebugString<T>(IList<T> list) {
        return list.Aggregate("", (collector, next) => collector + next.ToString() + "\n");
    }

    // Start is called before the first frame update
    void Start() {
        var gameDataManager = FindObjectOfType<GameDataManager>();
        var player = gameDataManager.Player;
        var inventory = player.Inventory;
        
        AddItem.OnClickAsObservable().Subscribe(_ => {
            inventory.Add(gameDataManager.GenerateTestItem());
        });
        DropItem.OnClickAsObservable().Subscribe(_ => {
            inventory.RemoveAt(0);
        });
        ChangeEquipment.OnClickAsObservable().Subscribe(_ => {
            var rand = new System.Random();
            var toSkip = rand.Next(0, player.AllItemSlots.Count());
            var randomSlot = player.AllItemSlots.Skip(toSkip).Take(1).First();
            randomSlot.Value = gameDataManager.GenerateTestItem();
        });

        player.Stats.SubscribeToText(PlayerInfo);
        inventory.ObserveCountChanged().StartWith(inventory.Count).Subscribe(_ => {
            InventoryInfo.text = ToDebugString(inventory);
        });

        AllItemsInfo.text = ToDebugString(gameDataManager.AllItems);
    }
}
