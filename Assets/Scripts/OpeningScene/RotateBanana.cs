using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBanana : MonoBehaviour {

    public float rotationSpeed;

    float time;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        gameObject.transform.eulerAngles = new Vector3(0, 0, rotationSpeed*time);
        if (rotationSpeed * time > 360)
            time = 0f;
            
	}
}
