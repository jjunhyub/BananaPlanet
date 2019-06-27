using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoveSlow : MonoBehaviour {
    public float speed;
    float t = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x <= -23000)
            t = 0;
        t += Time.deltaTime;
        gameObject.transform.position = new Vector3(23500 - t*speed, 0, 0);
		
	}
}
