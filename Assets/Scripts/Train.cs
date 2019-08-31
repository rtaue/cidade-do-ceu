using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour {
    public string nextLevel;
    private MainGame mainGame;
    public Animator anim;
    public GameObject lip;
    private CameraMovement cameraMovement;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public bool playSound;
    public GameObject smoke;

	// Use this for initialization
	void Start () {
        mainGame = GameObject.Find("MainGame").GetComponent<MainGame>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        playSound = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (mainGame.train && playSound)
        {
            audioS.PlayDelayed(2);
            playSound = false;
            smoke.SetActive(true);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player") && mainGame.train)
        {
            anim.SetTrigger("move");
            lip.SetActive(true);
            Destroy(collision.gameObject);
            cameraMovement.target = lip;
        }
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void TrainSound()
    {
        audioS.PlayOneShot(clip[1]);
    }
}
