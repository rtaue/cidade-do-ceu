using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
	public AudioSource audioS;
	public AudioClip[] clip = new AudioClip[1];

	public void Level11 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 1 - Tutorial");
	}

	public void Level12 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 1 - Parte 2");

	}

	public void Level21 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 2 - Parte 1");

	}

	public void Level22 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 2 - Parte 2");
	}

	public void Level31 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 3 - Parte 1");
	}

	public void Level32 () {
		audioS.PlayOneShot(clip[0]);
		SceneManager.LoadScene ("Level 3 - Parte 2");
	}

    public void Final()
    {
        audioS.PlayOneShot(clip[0]);
        SceneManager.LoadScene("End");
    }
}