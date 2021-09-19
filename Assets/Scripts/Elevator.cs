using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevator : MonoBehaviour
{
    public Transform destTransform;
    public float stopDistance = 0.1f;

    public float speed = 4f;

    public Transform parentObject;

    public float maxHeight = 10f;

    bool startElevator = false;

    Transform player;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = parentObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    private void FixedUpdate()
    {
        if (startElevator)
        {
            //if (Vector3.Distance(rb.position, destTransform.position) > stopDistance)
            {
                //Vector3 newPos = new Vector3(rb.position.x, Mathf.Lerp(transform.position.y, destTransform.position.y, Time.fixedDeltaTime * speed), rb.position.z);
                //rb.MovePosition(newPos);

                rb.transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(transform.position.y, transform.position.y + maxHeight, Time.fixedDeltaTime * speed), transform.position.z);
            }
            
        }

        if (rb.position.y >= destTransform.position.y)
        {
            startElevator = false;
            player.SetParent(transform.root);
            if (player.GetComponent<NavMeshAgent>())
                player.GetComponent<NavMeshAgent>().enabled = true;
            player = null;
            this.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            startElevator = true;
            Debug.Log("Start Elevator : " + startElevator);
            player = other.transform;

            if(player)
            {
                player.SetParent(parentObject);
                if(player.GetComponent<NavMeshAgent>())
                    player.GetComponent<NavMeshAgent>().enabled = false;
            }

            
        }
    }
}
