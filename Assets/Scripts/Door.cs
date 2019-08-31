using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public Lever lever;
    private MainGame mainGame;
    public Animator anim;
    public string nextLevel;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];


	// Use this for initialization
	void Start () {
        mainGame = GameObject.Find("MainGame").GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
        DoorMove();
	}

    private void DoorMove()
    {
        if (lever.openDoor && mainGame.door)
        {
            anim.SetTrigger("open");
            anim.ResetTrigger("close");
        }
        else
        {
            anim.SetTrigger("close");
            anim.ResetTrigger("open");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player") && lever.openDoor && mainGame.door)
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void DoorSound()
    {
        audioS.PlayOneShot(clip[0]);
    }
}
