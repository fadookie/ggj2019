using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float speed = 0.1f;
        Vector3 pos = new Vector3();
        if (Input.GetKey(KeyCode.D))
            pos.x += speed;
        if (Input.GetKey(KeyCode.A))
            pos.x -= speed;
        if (Input.GetKey(KeyCode.W))
            pos.y += speed;
        if (Input.GetKey(KeyCode.S))
            pos.y -= speed;
        transform.Translate(pos);
    }
}
