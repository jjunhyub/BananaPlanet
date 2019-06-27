using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour {
    public List<Image> PlanetStageImage = new List<Image>();
    public int planetNumber = 1;
    Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        image.sprite = PlanetStageImage[planetNumber - 1].sprite;
	}
}
