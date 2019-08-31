using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public Animator[] anim;
    public GameObject[] gameObject = new GameObject[3];

	public void Começar () {
        audioS.PlayOneShot(clip[0]);
        anim[0].SetTrigger("start");
		
	}

	public void LevelSelect () {
        audioS.PlayOneShot(clip[0]);
        gameObject[1].SetActive(false);
        gameObject[0].SetActive(false);
        gameObject[2].SetActive(true);
		
	}

    public void Extras()
    {
        audioS.PlayOneShot(clip[0]);
        gameObject[1].SetActive(true);
        gameObject[0].SetActive(false);

    }

    public void Creditos () {
        audioS.PlayOneShot(clip[0]);
        
		
	}
	
	public void Quit () {
        audioS.PlayOneShot(clip[0]);
        print ("Quit");
		Application.Quit();
	}

    public void Voltar()
    {
        audioS.PlayOneShot(clip[0]);
        gameObject[1].SetActive(false);
        gameObject[2].SetActive(false);
        gameObject[0].SetActive(true);
    }

    public void LIPMove()
    {
        anim[1].SetTrigger("move");
    }

    public void LIPStop()
    {
        anim[1].SetTrigger("stop");
        anim[1].ResetTrigger("move");
    }

    public void LIPup()
    {
        anim[1].SetTrigger("up");
        anim[1].ResetTrigger("move");

    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Pre Level 1");
    }
}
