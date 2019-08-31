using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {
    public string nextLevel;
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(nextLevel);
    }

    public void Next()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void LIPmove()
    {
        anim.SetTrigger("move");
    }

    public void LIPstop()
    {
        anim.SetTrigger("stop");
    }

    public void LIPbend()
    {
        anim.SetTrigger("bend");
    }
}
