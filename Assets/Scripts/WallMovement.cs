using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Move()
    {
        audioS.PlayOneShot(clip[0]);
    }
}
