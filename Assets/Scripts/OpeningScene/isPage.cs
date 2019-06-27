using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPage : MonoBehaviour {
    public float changeTime;
    public bool loadingEnd = false;
    float timeCheck = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCheck += Time.deltaTime;
        if (timeCheck > changeTime)
        {
            loadingEnd = true;
            gameObject.SetActive(false);
        }
	}
}
