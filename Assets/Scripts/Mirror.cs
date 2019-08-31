using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
    public Sprite[] mirror = new Sprite[7];
    public Sprite pop;
    private Inventory inventory;
    private PlayerMovement player;
    private SpriteRenderer spriteRenderer;
    public int actualMirror;
    public bool mirrorOn;
    public int rightMirror;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[4];
    private float counter;

	// Use this for initialization
	void Start () {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        player = GameObject.Find("player").GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (mirrorOn) counter += Time.deltaTime;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player") && Input.GetKeyDown(KeyCode.X))
        {

            if (player.mirror && !mirrorOn)
            {
                player.inventory = false;
                mirrorOn = true;
                actualMirror = inventory.mirror;
                spriteRenderer.sprite = mirror[inventory.mirror];
                player.mirror = false;

                if (actualMirror == rightMirror)
                {
                    audioS.PlayOneShot(clip[0]);
                }
                else
                {
                    audioS.PlayOneShot(clip[1]);
                }

            }
            else if (!player.mirror && mirrorOn && !player.inventory && counter > 3)
            {
                audioS.PlayOneShot(clip[2]);
                counter = 0;
                spriteRenderer.sprite = null;
                inventory.mirror = actualMirror;
                player.mirror = true;
                mirrorOn = false;
                player.inventory = true;
            }

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            if (!mirrorOn)
            {
                if (!audioS.isPlaying)
                {
                    audioS.PlayOneShot(clip[3]);
                }
                spriteRenderer.sprite = pop;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            if (!mirrorOn)
            {
                spriteRenderer.sprite = null;
            }
            
        }
    }
}
