using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farol : MonoBehaviour {
    private MainGame mainGame;
    private SpriteRenderer spriteRenderer;
    public Sprite[] farol = new Sprite[2];

	// Use this for initialization
	void Start () {
        mainGame = GameObject.Find("MainGame").GetComponent<MainGame>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (mainGame.load && mainGame.wheel && mainGame.rock)
        {
            spriteRenderer.sprite = farol[1];
        }
        else
        {
            spriteRenderer.sprite = farol[0];
        }
    }
}
