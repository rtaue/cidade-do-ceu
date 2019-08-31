using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public PlayerMovement player;
    public Image item;
    public GameObject refItem;
    //public GameObject Oil, Toolbox, Coal, Wheel, Pickaxe, Mirror;
    public int mirror;
    public Sprite[] mirrorType = new Sprite[7];
    public Sprite energybox, coal, oil, wheel, pickaxe;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void FixedUpdate()
    {
        SetItem();
        
    }

    
    private void SetItem()
    {
        if (player.coal)
        {
            refItem.SetActive(true);
            item.sprite = coal;
        }
        else if (player.oil)
        {
            refItem.SetActive(true);
            item.sprite = oil;
        }
        else if (player.toolbox)
        {
            refItem.SetActive(true);
            item.sprite = energybox;
        }
        else if (player.wheel)
        {
            refItem.SetActive(true);
            item.sprite = wheel;
        }
        else if (player.pickaxe)
        {
            refItem.SetActive(true);
            item.sprite = pickaxe;
        }
        else if (player.mirror)
        {
            refItem.SetActive(true);
            item.sprite = mirrorType[mirror];

        }
        else
        {
            refItem.SetActive(false);
        }
    }
}
