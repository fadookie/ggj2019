﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehaviour : MonoBehaviour
{
    private PlayerBehaviour playerBehaviour;
    private Text hpText, mpText, speedText;

    void Start()
    {
        playerBehaviour = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        hpText = transform.Find("HPvalue").gameObject.GetComponent<Text>();
        mpText = transform.Find("MPvalue").gameObject.GetComponent<Text>();
        speedText = transform.Find("Speedvalue").gameObject.GetComponent<Text>();
    }

    void Update()
    {
        hpText.text = playerBehaviour.HP.ToString();
        mpText.text = playerBehaviour.MP.ToString();
        speedText.text = playerBehaviour.Speed.ToString();
    }
}