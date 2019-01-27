using System.Linq;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        int artSprite = GameDataManager.instance.AllItems.Where(it => itemID == it.Id).Select(it => it.Art).First();
        Sprite sprite = GameDataManager.instance.itemSprites[artSprite];

        spriteRenderer.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerBehaviour beh = collider.gameObject.GetComponent<PlayerBehaviour>();
            beh.itemToPickup = this;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerBehaviour beh = collider.gameObject.GetComponent<PlayerBehaviour>();

            if (beh.itemToPickup == this)
            {
                beh.itemToPickup = null;
            }
        }
    }
}
