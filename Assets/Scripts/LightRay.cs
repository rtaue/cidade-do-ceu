using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRay : MonoBehaviour {
    public Mirror mirrorRef;
    public int rightMirror;
    public GameObject[] lightRay = new GameObject[7];
    public bool ray;
    public LightRay lr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mirrorRef.actualMirror == rightMirror && mirrorRef.mirrorOn && lr.ray)
        {
            ray = true;
            lightRay[mirrorRef.actualMirror].SetActive(true);
        }
        else if (mirrorRef.mirrorOn && lr.ray)
        {
            ray = false;
            lightRay[mirrorRef.actualMirror].SetActive(true);
        }
        else
        {
            for (int i = 0; i < lightRay.Length; i++)
            {
                ray = false;
                lightRay[i].SetActive(false);
            }
            
        }
	}
}
