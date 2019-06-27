using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    public List<Planet> planets = new List<Planet>();
    public Player player;
    public float gravityRadius;
    [HideInInspector]
    public float distance;
    public Shooter shooter;
    public float x, y, z;

	// Use this for initialization
	void Start (){
    }

    void Update () {
    }
}
