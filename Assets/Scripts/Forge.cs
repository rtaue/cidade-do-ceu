using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour {
    public MainGame mainGame;
    public GameObject lightForge;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainGame.forge)
        {
            if (!audioS.isPlaying)
            {
                audioS.PlayOneShot(clip[0]);
            }
            
            lightForge.SetActive(true);
        }
        else
        {
            lightForge.SetActive(false);
        }
	}
}
