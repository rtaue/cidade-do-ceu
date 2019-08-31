using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite tutorial;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tutorial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            spriteRenderer.enabled = false;
        }
    }
}
