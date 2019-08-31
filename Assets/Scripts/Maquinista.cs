using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinista : MonoBehaviour {
    public Sprite[] maquinista = new Sprite[3];
    private MainGame mainGame;
    public GameObject refPlayer;
    private SpriteRenderer spriteRenderer;

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
        if (refPlayer != null)
        {
            if (mainGame.load)
            {
                spriteRenderer.sprite = maquinista[2];
            }
            else if (refPlayer.transform.position.x < this.transform.position.x)
            {
                spriteRenderer.sprite = maquinista[1];
            }
            else
            {
                spriteRenderer.sprite = maquinista[0];
            }
        }
        
    }
}
