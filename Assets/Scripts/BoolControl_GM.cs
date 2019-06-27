using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolControl_GM : MonoBehaviour {
    public bool planetDisposeEnd;
	// Use this for initialization
	void Start () {
        planetDisposeEnd = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("planetDisposeEnd : " + planetDisposeEnd);
	}
    public void PlanetDisposeEndTrue()
    {
        planetDisposeEnd = true;
    }
    public void PlanetDisposeEndFalse()
    {
        planetDisposeEnd = false;
    }
}
