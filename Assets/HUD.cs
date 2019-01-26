using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public float HP, MP, Speed;
    private Text hpText, mpText, speedText;
    void Start()
    {
        hpText = transform.Find("HPvalue").gameObject.GetComponent<Text>();
        mpText = transform.Find("MPvalue").gameObject.GetComponent<Text>();
        speedText = transform.Find("Speedvalue").gameObject.GetComponent<Text>();
    }

    void Update()
    {
        hpText.text = HP.ToString();
        mpText.text = MP.ToString();
        speedText.text = Speed.ToString();
    }
}
