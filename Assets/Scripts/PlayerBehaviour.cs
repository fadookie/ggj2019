using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP = 100, MP = 100, Speed = 100;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
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

        Vector2 size = new Vector2(1, 1);
        float distance = Speed * 0.05f * Time.deltaTime;
        Vector3 newpos = direction * distance;
        int layerMask = LayerMask.GetMask("Solid Objects");

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, size, 0.0f, direction, distance, layerMask);

        if (!hit)
            transform.Translate(newpos); 
    }
}
