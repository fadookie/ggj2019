using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;

    public SpriteRenderer spriteRenderer;

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
