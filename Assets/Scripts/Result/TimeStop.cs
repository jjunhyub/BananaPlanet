using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour {
    public List<Image> timeImages = new List<Image>();
    public List<Image> resultTimeImages = new List<Image>();
    // Use this for initialization
    void Start () {
        for (int i = 0; i < resultTimeImages.Count; i++)
        {
            resultTimeImages[i].sprite = timeImages[i].sprite;
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
