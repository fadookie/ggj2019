using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    
    public Transform openPosition;
    public Transform closedPosition;

    [SerializeField]
    private Transform doorBody = null;

    [SerializeField]
    private float timeToClose = 1.0f;
    
    private float timer = 0.0f;
    
    private bool open = false;


    [SerializeField]
    private bool triggerOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeToClose;

        doorBody.transform.position = open ? openPosition.position : closedPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerOpen != open)
        {
            SetOpen(triggerOpen);
        }

        Vector3 target;
        Vector3 source;

        if (open)
        {
            source = closedPosition.position;
            target = openPosition.position;
        }
        else
        {
            target = closedPosition.position;
            source = openPosition.position;
        }

        if (timer < timeToClose)
        {
            timer += Time.deltaTime;

            doorBody.transform.position = Vector3.Lerp(source, target, timer / timeToClose);
        }
        else if (timer > timeToClose)
        {
            timer = timeToClose;
            doorBody.transform.position = target;
        }
    }

    private void SetOpen(bool openDoor)
    {
        if (open != openDoor)
        {
            open = openDoor;
            timer = timeToClose - timer;
        }
    }

    public void Open()
    {
        triggerOpen = true;
    }

    public void Close()
    {
        triggerOpen = false;
    }
}
