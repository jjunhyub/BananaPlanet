using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

	public Transform orbitingObject;
	public Ellipse orbitPath;

	[Range(0f,1f)]
	public float orbitProgress = 0f;
	public float orbitPeriod = 3f;
	public bool orbitActive = true; 


	// Use this for initialization
	void Start () {
		if (orbitingObject == null) {
			orbitActive = false;
			return;
		} else {
			SetOrbitingObjectPosition ();
			StartCoroutine (AnimateOrbit ());
		}
	}
		
	
	void SetOrbitingObjectPosition(){
		Vector2 orbitPos = orbitPath.Evaluate (orbitProgress);
		orbitingObject.position = new Vector3 (orbitPos.x+this.transform.position.x, orbitPos.y+this.transform.position.y, 0.1f);
	}

	IEnumerator AnimateOrbit(){
		if (orbitPeriod < 0.1f) {
			orbitPeriod = 0.1f;
		}
		float OrbitSpeed = 1f / orbitPeriod;
		while (orbitActive) {
			print (1);
			orbitProgress += Time.deltaTime * OrbitSpeed;
			orbitProgress %= 1f;
			SetOrbitingObjectPosition ();
			yield return null;
		}
	}

	
}
