 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private MainGame mainGame;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainGame = GameObject.Find("MainGame").GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainGame.wheel)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
	}
}
