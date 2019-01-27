using Data.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP = 100, MP = 100, Speed = 100;

    public bool isOverWeight;

    private Rigidbody2D rb;
    private Animator animator;
    private int dir = 0;
  private bool pickingup = false;

    public List<ItemPickup> itemToPickups;

  
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        if (GameDataManager.instance)
            GameDataManager.instance.playerObject = gameObject;
    }

    void UpdateAnimation(Vector2 direction)
    {
        bool isMoving = true;
        int currentDir = dir;

        if (direction.x > 0)
            dir = 4;
        else if (direction.x < 0)
            dir = 2;
        else if (direction.y < 0)
            dir = 1;
        else if (direction.y > 0)
            dir = 3;
        else
            isMoving = false;

        if (isMoving)
            animator.speed = 1.0f;
        else
            animator.speed = 0.0f;

        if(currentDir != dir)
            animator.SetInteger("direction", dir);
    }

    void Update()
    {
      var gdm = GameDataManager.instance;
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.D))
            direction.x += 1.0f;
        if (Input.GetKey(KeyCode.A))
            direction.x -= 1.0f;
        if (Input.GetKey(KeyCode.W))
            direction.y += 1.0f;
        if (Input.GetKey(KeyCode.S))
            direction.y -= 1.0f;

    if (!pickingup && Input.GetKeyDown(KeyCode.E))
    {
      pickingup = true;
      HandleItemPickupCall();
    }
    else if (!Input.GetKeyDown(KeyCode.E)) {
      pickingup = false;
    }

        //Vector2 direction;
        //direction.x = Input.GetAxis("Horizontal");
        //direction.y = Input.GetAxis("Vertical");

        Vector2 size = new Vector2(1, 1);
    float weightBurden = Mathf.Clamp((float)gdm.Player.getInventoryWeight() / 100f, .1f, .9f);//isOverWeight ? 0.90f : 0;
        float distance = Speed * (1 - weightBurden) * 0.05f * Time.deltaTime;
        int layerMask = LayerMask.GetMask("Solid Objects");

        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(layerMask);
        RaycastHit2D[] results = new RaycastHit2D[1];

        if (rb.Cast(direction, contactFilter, results, distance) == 0)
        {
            Vector3 newpos = direction * distance;
            transform.Translate(newpos);
            UpdateAnimation(direction);
            return;
        }

        Vector3 horizDirection = new Vector3();
        horizDirection.x = direction.x;
        if (rb.Cast(horizDirection, contactFilter, results, distance) == 0)
        {
            Vector3 newpos = horizDirection * distance;
            transform.Translate(newpos);
            return;
        }

        Vector3 vertDirection = new Vector3();
        vertDirection.y = direction.y;
        if (rb.Cast(vertDirection, contactFilter, results, distance) == 0)
        {
            Vector3 newpos = vertDirection * distance;
            transform.Translate(newpos);
            return;
        }

    }

    void HandleItemPickupCall()
    {
        if (itemToPickups.Count > 0)
        {
            ItemPickup itemToPickup = itemToPickups.First();
        itemToPickups.Remove(itemToPickup);
            Item item = GameDataManager.instance.AllItems.Where(it => (it != null && it.Id == itemToPickup.itemID)).FirstOrDefault();

            if (item == null)
            {
                Debug.LogError("Missing item with item ID: " + itemToPickup.itemID);
            }
            else
            {
                GameDataManager.instance.Player.Inventory.Add(item.getItem());
                Destroy(itemToPickup.gameObject);

                foreach(Item it in GameDataManager.instance.Player.Inventory)
                {
                    Debug.Log(it);
                }

                
            }
        }
    }
}
