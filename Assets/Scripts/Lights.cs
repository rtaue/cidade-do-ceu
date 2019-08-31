using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {
    public MainGame _mg;
    public string refObject;
    public Sprite[] lightColor = new Sprite[2];
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public bool playAudio = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (refObject == "wire")
        {
            if (_mg.wire)
            {
                if (!audioS.isPlaying && playAudio)
                {
                    audioS.PlayOneShot(clip[0]);
                    playAudio = false;
                }
                this.GetComponent<SpriteRenderer>().sprite = lightColor[1];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = lightColor[0];
            }
        }
        else if (refObject == "door")
        {
            if (_mg.door)
            {
                if (!audioS.isPlaying && playAudio)
                {
                    audioS.PlayOneShot(clip[0]);
                    playAudio = false;
                }
                this.GetComponent<SpriteRenderer>().sprite = lightColor[1];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = lightColor[0];
            }
        }
        else if (refObject == "lever")
        {
            if (_mg.lever)
            {
                if (!audioS.isPlaying && playAudio)
                {
                    audioS.PlayOneShot(clip[0]);
                    playAudio = false;
                }
                this.GetComponent<SpriteRenderer>().sprite = lightColor[1];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = lightColor[0];
            }
        }
        else if (refObject == "forge")
        {
            if (_mg.forge)
            {
                if (!audioS.isPlaying && playAudio)
                {
                    audioS.PlayOneShot(clip[0]);
                    playAudio = false;
                }
                this.GetComponent<SpriteRenderer>().sprite = lightColor[1];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = lightColor[0];
            }
        }
        else if (refObject == "wheel")
        {
            if (_mg.wheel)
            {
                if (!audioS.isPlaying && playAudio)
                {
                    audioS.PlayOneShot(clip[0]);
                    playAudio = false;
                }
                this.GetComponent<SpriteRenderer>().sprite = lightColor[1];
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = lightColor[0];
            }
        }
        

    }

    
}
