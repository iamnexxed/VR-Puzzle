using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float speedH = 2f;
    public float speedV = 2f;

    float yaw = 0f;
    float pitch = 0f;

    public bool lockCam;

    Quaternion camRotation;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;

#endif
    }

    // Update is called once per frame
    void Update()
    {
        if(lockCam)
        {
            camRotation = transform.rotation;
            return;
        }

#if UNITY_EDITOR
        MoveCam();
#endif
    }

    void MoveCam()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Debug.Log("Mouse Rotation is : " + new Vector3(pitch, yaw, 0f));

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }

}
