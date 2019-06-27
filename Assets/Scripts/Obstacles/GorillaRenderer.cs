using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class GorillaRenderer : MonoBehaviour {

	public LineRenderer lr;
	Gorilla gorilla;

	void Awake(){
		lr = GetComponent<LineRenderer>();
		gorilla = GetComponent<Gorilla> ();

	}

}
