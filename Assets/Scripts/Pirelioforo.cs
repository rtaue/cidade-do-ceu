using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirelioforo : MonoBehaviour {
    public LightRay lr;
    public AudioSource audioS;
    public AudioClip clip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lr.ray)
        {
            if (!audioS.isPlaying)
            {
                audioS.PlayOneShot(clip);
            }
        }
	}
}
