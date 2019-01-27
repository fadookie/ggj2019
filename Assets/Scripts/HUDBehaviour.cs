using System.Collections;
using System.Collections.Generic;
using Data.Model;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehaviour : MonoBehaviour
{
    private Text hpText, mpText, speedText;
    private Player player;

    void Start() {
        hpText = transform.Find("HPvalue").gameObject.GetComponent<Text>();
        mpText = transform.Find("MPvalue").gameObject.GetComponent<Text>();
        speedText = transform.Find("Speedvalue").gameObject.GetComponent<Text>();
        player = GameDataManager.instance.Player;
        player.Stats.AsObservable()
            .Subscribe(stats => {
                hpText.text = stats.Hp.ToString();
                mpText.text = stats.Mp.ToString();
                speedText.text = stats.Speed.ToString();
            });
    }
}