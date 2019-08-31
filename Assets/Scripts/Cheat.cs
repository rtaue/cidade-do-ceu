using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour {
    public GameObject[] gameObject = new GameObject[3];
    public AudioSource audioS;
    public AudioClip clip;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        audioS.PlayOneShot(clip);
        gameObject[1].SetActive(false);
        gameObject[0].SetActive(false);
        gameObject[2].SetActive(true);
    }
}
