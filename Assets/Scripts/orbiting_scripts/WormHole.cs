using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHole : MonoBehaviour {


	public GameObject whiteHole;
	public GameObject blackHole;

    public float speed;
	public float radius;
	GameObject banana;
    bool isOutWhite, isOutBlack;
    float t;
	// Use this for initialization
	void Start(){
		banana = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        whiteHole.transform.rotation = Quaternion.Euler(0, 0, t * speed);
        blackHole.transform.rotation = Quaternion.Euler(0, 0, t * speed);


        if (dist(banana.transform.position,blackHole.transform.position)<radius) {
            if(isOutBlack)
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayWarp();
                banana.transform.position = whiteHole.transform.position;
                isOutBlack = false;
                isOutWhite = false;
            }
		}
        else
        {
            isOutBlack = true;
        }
        if (dist(banana.transform.position, whiteHole.transform.position) < radius)
        {
            if (isOutWhite)
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayWarp();
                banana.transform.position = blackHole.transform.position;
                isOutBlack = false;
                isOutWhite = false;
            }
        }
        else
        {
            isOutWhite = true;
        }
    }
	float dist(Vector3 a, Vector3 b){
		float c = a.x - b.x;
		float d = a.y - b.y;
		return Mathf.Sqrt (d * d + c * c);
	}

}
