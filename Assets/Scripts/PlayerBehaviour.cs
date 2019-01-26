﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int HP, MP, Speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void Update()
    {
        float speed = Speed * 0.05f * Time.deltaTime;
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
