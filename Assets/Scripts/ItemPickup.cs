using Data.Model;
using System.Linq;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {

        Item item = GameDataManager.instance.AllItems.Where(it => itemID == it.Id).FirstOrDefault();

        if (item == null)
        {
            if (itemID != -1)
            {
                Debug.LogWarning("Missing item for id=" + itemID + ". Picking an item at random.");
            }
            int itemSize = GameDataManager.instance.AllItems.Count;
            item = GameDataManager.instance.AllItems[Random.Range(0, (int)itemSize)];

            itemID = item.Id;
        }


        int artSprite = GameDataManager.instance.AllItems.Where(it => itemID == it.Id).Select(it => it.Art).First();
        Sprite sprite = GameDataManager.instance.itemSprites[artSprite];

        spriteRenderer.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerBehaviour beh = collider.gameObject.GetComponent<PlayerBehaviour>();
            beh.itemToPickups.Add(this);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerBehaviour beh = collider.gameObject.GetComponent<PlayerBehaviour>();

            if (beh.itemToPickups.Contains(this))
            {
                beh.itemToPickups.Remove(this);
            }
        }
    }
}
