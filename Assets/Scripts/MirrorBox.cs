using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBox : MonoBehaviour {

    private Inventory inventory;
    private PlayerMovement player;
    public int mirrorCount;
    public int[] mirrorType = new int[2];
    private SpriteRenderer spriteRenderer;
    public Sprite[] box = new Sprite[4];
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];

	// Use this for initialization
	void Start () {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        player = GameObject.Find("player").GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        spriteRenderer.sprite = box[mirrorCount];
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name.Contains("player") && Input.GetKeyDown(KeyCode.X))
        {

            if (!player.mirror && mirrorCount > 0)
            {
                audioS.PlayOneShot(clip[0]);
                player.mirror = true;
                player.inventory = true;
                inventory.mirror = mirrorType[mirrorCount-1];
                mirrorCount--;
            }
            
        }
    }
}
