using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP = 100, MP = 100, Speed = 100;
    private Rigidbody2D rb;
    private Animator animator;
    private int dir = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
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
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.D))
            direction.x += 1.0f;
        if (Input.GetKey(KeyCode.A))
            direction.x -= 1.0f;
        if (Input.GetKey(KeyCode.W))
            direction.y += 1.0f;
        if (Input.GetKey(KeyCode.S))
            direction.y -= 1.0f;

        //Vector2 direction;
        //direction.x = Input.GetAxis("Horizontal");
        //direction.y = Input.GetAxis("Vertical");

        Vector2 size = new Vector2(1, 1);
        float distance = Speed * 0.05f * Time.deltaTime;
        int layerMask = LayerMask.GetMask("Solid Objects");

        //ContactFilter2D contactFilter = new ContactFilter2D();
        //contactFilter.SetLayerMask(layerMask);
        //RaycastHit2D[] results = new RaycastHit2D[2];
        //int count = rb.Cast(direction, contactFilter, results, distance);
        //if (count > 0)

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, size, 0.0f, direction, distance, layerMask);
        if (!hit) {
            Vector3 newpos = direction * distance;
            transform.Translate(newpos);
            UpdateAnimation(direction);
            return;
        }

        Vector3 horizDirection = new Vector3();
        horizDirection.x = direction.x;
        hit = Physics2D.BoxCast(transform.position, size, 0.0f, horizDirection, distance, layerMask);
        if (!hit)
        {
            Vector3 newpos = horizDirection * distance;
            transform.Translate(newpos);
            return;
        }

        Vector3 vertDirection = new Vector3();
        vertDirection.y = direction.y;
        hit = Physics2D.BoxCast(transform.position, size, 0.0f, vertDirection, distance, layerMask);
        if (!hit) {
            Vector3 newpos = vertDirection * distance;
            transform.Translate(newpos);
            return;
        }

    }
}
