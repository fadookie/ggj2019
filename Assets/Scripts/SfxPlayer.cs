using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    public static SfxPlayer instance;

    public AudioClip ClickSound;
    public AudioClip DropSound;
    public AudioClip PickupSound;

    private AudioSource player;

    public enum Sound
    {
        Click,
        Drop,
        Pickup
    }

    void Awake() {
        // Singleton setup;
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;

        player = GetComponent<AudioSource>();
    }

    void Start() {
        GameDataManager.instance.Player.Inventory.ObserveAdd().AsObservable()
            .Subscribe(_ => {
                PlaySound(Sound.Pickup);
            });
        GameDataManager.instance.Player.Inventory.ObserveRemove().AsObservable()
            .Subscribe(_ => {
                PlaySound(Sound.Drop);
            });
    }

    public void PlaySound(Sound sound) {
        switch (sound) {
            case Sound.Click:
                PlayClip(ClickSound);
                break;
            case Sound.Drop:
                PlayClip(DropSound);
                break;
            case Sound.Pickup:
                PlayClip(PickupSound);
                break;
        }
    }

    private void PlayClip(AudioClip clip) {
        player.PlayOneShot(clip);
    }
}