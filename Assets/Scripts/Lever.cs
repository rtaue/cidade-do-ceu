using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    public MainGame mainGame;
    public Animator anim;
    public bool openDoor;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public bool playSound;

	// Use this for initialization
	void Start () {
        playSound = true;
	}
	
	// Update is called once per frame
	void Update () {
        LeverMove();
	}

    private void LeverMove()
    {
        if (mainGame.lever)
        {
            if (!audioS.isPlaying && playSound)
            {
                audioS.PlayOneShot(clip[0]);
                playSound = false;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (!openDoor)
                {
                    openDoor = true;
                    anim.SetTrigger("open");
                    anim.ResetTrigger("close");
                }
                else
                {
                    openDoor = false;
                    anim.SetTrigger("close");
                    anim.ResetTrigger("open");
                }
            }
        }
    }
}
