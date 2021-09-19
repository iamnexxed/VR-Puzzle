using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openDistance = 5f;
    public float openSpeed = 10f;

    bool shouldOpen = false;

    float openPosition;
    // Start is called before the first frame update
    void Start()
    {
        openPosition = transform.position.x + openDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldOpen)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, openPosition, Time.deltaTime * openSpeed), transform.position.y, transform.position.z);
        }
    }

    public void OpenDoor()
    {
        shouldOpen = true;
        Debug.Log("Open Door : " + shouldOpen);
    }
}
