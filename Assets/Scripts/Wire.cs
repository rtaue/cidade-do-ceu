using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {
    public Sprite[] objSprites = new Sprite[2];
    public PlayerMovement _pm;
    public MainGame _mg;
    public SpriteRenderer _sr;
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
            if (_mg.wire)
            {
                if (!audioS.isPlaying && playSound)
            {
                audioS.PlayOneShot(clip[0]);
                playSound = false;
            }
                _sr.sprite = objSprites[1];
            }
            else
            {
                _sr.sprite = objSprites[0];
            }

    }
}
