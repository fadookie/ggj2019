using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ExitBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("onTurnOn")]
    public UnityEvent onExit;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onExit.Invoke();
            TriggerEndScene();
        }
    }

    public void TriggerEndScene()
    {
        SceneManager.LoadScene("Scenes/EndScreen", LoadSceneMode.Single);
    }

}
