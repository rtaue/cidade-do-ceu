using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPopUp : MonoBehaviour {
    public GameObject _popUp;
    public MainGame _mg;
    public string _refObj;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            PopUp();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            
            PopOut();
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {

            _popUp.SetActive(false);

        }

    }

    private void PopUp()
    {

        if (_refObj == "wire" && !_mg.wire)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }
        else if (_refObj == "lever" && !_mg.lever)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }
        else if (_refObj == "forge" && !_mg.forge)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }
        else if (_refObj == "rock" && !_mg.rock)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }
        else if (_refObj == "wheel" && !_mg.wheel)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }
        else if (_refObj == "load" && !_mg.load)
        {
            audioS.PlayOneShot(clip[0]);
            _popUp.SetActive(true);

        }

    }
    
    private void PopOut()
    {

        if (_refObj == "wire" && _mg.wire)
        {
            _popUp.SetActive(false);

        }
        else if (_refObj == "lever" && _mg.lever)
        {
            _popUp.SetActive(false);

        }
        else if (_refObj == "forge" && _mg.forge)
        {
            _popUp.SetActive(false);

        }
        else if (_refObj == "rock" && _mg.rock)
        {
            _popUp.SetActive(false);

        }
        else if (_refObj == "wheel" && _mg.wheel)
        {
            _popUp.SetActive(false);

        }
        else if (_refObj == "load" && _mg.load)
        {
            _popUp.SetActive(false);

        }

    }
}
