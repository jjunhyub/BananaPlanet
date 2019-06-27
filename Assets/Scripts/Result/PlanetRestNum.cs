using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRestNum : MonoBehaviour {

    public List<TargetImage> targetImages = new List<TargetImage>();
    public List<Image> planetNumImages = new List<Image>();
    [HideInInspector]
    public List<int> planetRestNum = new List<int>();

    Image image;

    int total;
    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        total = 0;
        for(int i = 0;i<targetImages.Count;i++)
        {
            planetRestNum[i] = targetImages[i].planetNum - targetImages[i].planetCount;
            total += planetRestNum[i];
        }
        Debug.Log("이미지 변환이 일어나려한다");
        image.sprite = planetNumImages[total].sprite;

    }

    // Update is called once per frame
    void Update()
    {

    }
}