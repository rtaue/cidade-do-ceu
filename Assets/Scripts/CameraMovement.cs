using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    public Camera mainCamera;
    public Camera farCamera;
    public float cameraSpeed;
    public float cameraStandard = 5;
    public float cameraZoom = 10;

    // Use this for initialization
    void Start () {
        targetPos = transform.position;
   }

    // Update is called once per frame
    void FixedUpdate () {
    if (target)
    {
        Vector3 posNoZ = transform.position;
        posNoZ.z = target.transform.position.z;

        Vector3 targetDirection = (target.transform.position - posNoZ);

        interpVelocity = targetDirection.magnitude * 5f;

        targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

        transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

    }

        ZoomInOut();

        UpdateCameras();
        
  }

    private void ZoomInOut()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Camera.main.orthographicSize += cameraSpeed;
            if (Camera.main.orthographicSize > cameraZoom)
            {
                Camera.main.orthographicSize = cameraZoom;
            }
            
        }
        else
        {
            Camera.main.orthographicSize -= cameraSpeed;
            if (Camera.main.orthographicSize < cameraStandard)
            {
                Camera.main.orthographicSize = cameraStandard;
            }
            
        }
        /*
        if (Camera.main.orthographicSize == 5 && Input.GetKeyDown(KeyCode.Z))
        {

            Camera.main.orthographicSize += cameraSpeed;

        } else if (Camera.main.orthographicSize == 10 && Input.GetKeyDown(KeyCode.Z))
        {

            Camera.main.orthographicSize = 5;
            
        }*/

    }

    public void UpdateCameras()
    {
        if (mainCamera == null || farCamera == null) return;

        // orthoSize
        float a = mainCamera.orthographicSize;
        // distanceFromOrigin
        float b = Mathf.Abs(mainCamera.transform.position.z);

        //change clipping planes based on main camera z-position
        farCamera.nearClipPlane = b;
        farCamera.farClipPlane = mainCamera.farClipPlane;
        

        //update field fo view for parallax cameras
        float fieldOfView = Mathf.Atan(a / b) * Mathf.Rad2Deg * 2f;
        farCamera.fieldOfView = fieldOfView;
    }
}