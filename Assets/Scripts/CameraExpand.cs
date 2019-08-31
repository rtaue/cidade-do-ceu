using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExpand : MonoBehaviour {
    public CameraMovement cameraMovement;
    public bool cameraMove;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdate()
    {
        if (cameraMove)
        {
            cameraMovement.cameraStandard += 0.01f;
            if(cameraMovement.cameraStandard > 8)
            {
                cameraMovement.cameraStandard = 8;
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            cameraMove = true;
            
        }
       
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            cameraMove = false;
            cameraMovement.cameraStandard = 5;
        }
    }
}
