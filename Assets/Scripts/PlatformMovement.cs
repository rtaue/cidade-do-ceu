using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
    public PlatformTrigger _pt;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public bool playSound;
        
	// Use this for initialization
	void Start () {
        playSound = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
      
        Move();
    }

    private void Move()
    {

        if (_pt.move)
        {
            if (!audioS.isPlaying && playSound)
            {
                audioS.PlayOneShot(clip[0]);
                playSound = false;
            }
            this.GetComponent<FixedJoint2D>().enabled = false;
            
        }
        
    }

}
