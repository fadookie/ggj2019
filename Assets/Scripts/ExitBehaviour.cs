using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ExitBehaviour : MonoBehaviour
{
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;

    public SpriteRenderer buttonOn;
    public SpriteRenderer buttonOff;

    private List<GameObject> weights = new List<GameObject>();

    public bool isOn = false;

    private bool wasOn = false;

    private void Awake()
    {
        //buttonOn.gameObject.SetActive(isOn);
        //buttonOff.gameObject.SetActive(!isOn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if ("Player" == collision.gameObject.tag || "ItemPickup" == collision.gameObject.tag )
        //{
        //    weights.Add(collision.gameObject);
        //    isOn = true;
        //}

        SceneManager.LoadScene("Scenes/EndScreen", LoadSceneMode.Single);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ("Player" == collision.gameObject.tag || "ItemPickup" == collision.gameObject.tag)
        {
            weights.Remove(collision.gameObject);
            isOn = weights.Count > 0;
        }
    }

    private void Update()
    {
        CheckTrigger();
    }

    private void CheckTrigger()
    {
        if (wasOn != isOn)
        {
            if (isOn)
            {
                onTurnOn.Invoke();
            }
            else
            {
                onTurnOff.Invoke();
            }
            
            buttonOn.gameObject.SetActive(isOn);
            buttonOff.gameObject.SetActive(!isOn);
            wasOn = isOn;
        }
    }

}
