using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : PlayerMovement {
    public GameObject _refPlayer;
    public float playerDistance;
    public bool move;

	// Use this for initialization
	void Start () {
        base._rdb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        
    }

    void FixedUpdate()
    {

        base.ChangeDirection(base.xmove);
        Follow();

        
        
    }

    private void Follow()
    {
        if (_refPlayer != null)
        {
            if (transform.position.x < (_refPlayer.transform.position.x - playerDistance))
            {
                base.xmove = 1;
            }
            else if (transform.position.x > (_refPlayer.transform.position.x + playerDistance))
            {
                base.xmove = -1;
            }
            else
            {
                base.xmove = 0;
            }

            if (move)
            {
                if (!base.audioS.isPlaying && base.xmove != 0)
                {
                    base.audioS.PlayOneShot(clip[0]);
                }
                else if (base.xmove == 0)
                {
                    base.audioS.Stop();
                }
                base.Movement(base.xmove);
                
            }
            else
            {
                base.audioS.Stop();
            }
        }
        
    }
}
