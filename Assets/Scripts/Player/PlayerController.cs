using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SpatialTracking;

public class PlayerController : MonoBehaviour
{
    public TrackedPoseDriver poseDriver;
    public CameraRotate cameraRotate;
    NavMeshAgent agent;

    Vector3 prevPos;
    float curSpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(!agent)
        {
            Debug.Log("Player NavMesh Agent Not Found.");
        }
        poseDriver.enabled = true;
        cameraRotate.enabled = true;
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Calculate Velocity
        //Vector3 curMove = transform.position - prevPos;
        //curSpeed = curMove.magnitude / Time.deltaTime;
        //prevPos = transform.position;

        if (agent.velocity.magnitude >= 0.1f)
        {
            // cameraRotate.lockCam = true;
        }
        else
        {
            
        }

        //if (agent.hasPath && agent.velocity.magnitude < 0.5f && agent.acceleration < 0f)
        //{
        //    // cameraRotate.lockCam = false;
        //    agent.velocity = Vector3.zero;
        //    agent.ResetPath();
        //}
    }


    public void MoveTo(Vector3 movePosition)
    {
        agent.SetDestination(movePosition);
    }

    
}
