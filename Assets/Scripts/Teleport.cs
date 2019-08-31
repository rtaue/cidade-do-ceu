using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {
    public LightRay lightRay;
    public string nextLevel;
    private SpriteRenderer spriteRenderer;
    public Sprite[] teleport = new Sprite[2];
    public Animator[] anim = new Animator[2];
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[2];


	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();


	}
	
	// Update is called once per frame
	void Update () {
		if (lightRay.ray)
        {
            spriteRenderer.sprite = teleport[1];
        }
        else
        {
            spriteRenderer.sprite = teleport[0];
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player") && lightRay.ray)
        {
            anim[0].SetTrigger("tp");
            audioS.PlayOneShot(clip[0]);
            Destroy(collision.gameObject);
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void TPeffect()
    {
        anim[1].SetTrigger("effect");
    }

    public void Sound()
    {
        audioS.PlayOneShot(clip[1]);
    }

}
