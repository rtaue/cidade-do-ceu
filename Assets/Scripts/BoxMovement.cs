using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {
    public bool grabed;
    private float xPos;
    public float imovableMass = 500f;
    private float defaultMass;

	// Use this for initialization
	void Start () {

        xPos = transform.position.x;
        defaultMass = this.GetComponent<Rigidbody2D>().mass;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

        Movement();

    }

    private void Movement()
    {

        if (!grabed)
        {
            this.GetComponent<Rigidbody2D>().mass = imovableMass;
            transform.position = new Vector3(xPos, transform.position.y);

        }
        else
        {

            this.GetComponent<Rigidbody2D>().mass = defaultMass;
            xPos = transform.position.x;

        }

    }
}
