using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{


    private GameObject nextObject;

    public GameObject Next
    {
        get
        {
            return nextObject;
        }
        set
        {
            nextObject = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nextObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
