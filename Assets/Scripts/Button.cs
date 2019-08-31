using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public Animator _animator;
    public bool player;
    public bool box;
    public bool companion;
    public Sprite[] button = new Sprite[2];
    private SpriteRenderer spriteRenderer;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];
    public bool playSound;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playSound = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playSound)
        {
            playSound = false;
            audioS.PlayOneShot(clip[0]);
        }
       

        spriteRenderer.sprite = button[1];

        if (collision.gameObject.name.Contains("player"))
        {
            player = true;
            
        }
        else if (collision.gameObject.name.Contains("companion"))
        {
            companion = true;
            
        }
        else if (collision.gameObject.name.Contains("box"))
        {
            box = true;
            
        }

        if (player || companion || box)
        {
            _animator.SetBool("move", true);
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        

        if (collision.gameObject.name.Contains("player"))
        {
            player = false;
        }
        else if (collision.gameObject.name.Contains("companion"))
        {
            companion = false;
        }
        else if (collision.gameObject.name.Contains("box"))
        {
            box = false;
        }

        if (!player && !companion && !box)
        {
            spriteRenderer.sprite = button[0];

            _animator.SetBool("move", false);

            playSound = true;
        }
        
    }
}
