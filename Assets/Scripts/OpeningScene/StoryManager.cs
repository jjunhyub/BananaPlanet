using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour {
    public List<Image> imageList = new List<Image>();
    [HideInInspector]
    public bool storyStart = true;

    GameObject imageObject;
    Color32 color;

    float time;
	
    // Use this for initialization
	void Start () {
        storyStart = true;
        if (GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().checkstory) TurnOff();
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().LobbyMusic();
        GameObject.FindGameObjectWithTag("ImsiSelect").GetComponent<PlanetRotator>().ImsiSelect();
        GameObject.FindGameObjectWithTag("ImsiSelect2").GetComponent<LeftBarUnderLine>().ImsiSelect();
    }
	
	// Update is called once per frame
	void Update () {
        if (storyStart)
        {
            Debug.Log("xzcz");
            StartCoroutine(StoryChange(2,2,2));
            storyStart = false;
        }

    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
    IEnumerator StoryChange(float fadeInLength, float stayLength, float fadeOutLength)
    {
        for (int i = 0; i < imageList.Count; i++)
        {
            imageObject = imageList[i].gameObject;
            imageObject.SetActive(true);
            imageList[i].color = new Color(0, 0, 0, 1);         // fade의 목표 : (0,0,0,1)->(1,1,1,1);
            StartCoroutine(FadeIn(fadeInLength,i));                        //서서히 밝아지려고 함
            /*yield return StartCoroutine(FadeIn(i));*/         //밝아질 때까지  기다림
            yield return new WaitForSeconds(fadeInLength+stayLength);                 //전부다 밝아지고나서 2초를 기다리려함
            imageList[i].color = new Color(1, 1, 1, 1);
            StartCoroutine(FadeOut(fadeOutLength,i));
            yield return new WaitForSeconds(fadeOutLength);//서서히 어두워지려고 함
            imageList[i].color = new Color(0, 0, 0, 1);
            /*yield return StartCoroutine(FadeOut(i)); */       //어두워질 때까지  기다림
            imageObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(float fadeInLength,int imageNum)
    {
       
        if (fadeInLength < 0.1f)
        {
            fadeInLength = 0.1f;
        }
        float changeSpeed = 1f / fadeInLength;
        while (imageList[imageNum].color.r<1&& imageList[imageNum].color.b < 1&& imageList[imageNum].color.g < 1)
        {

            imageList[imageNum].color += new Color(Time.deltaTime * changeSpeed , Time.deltaTime * changeSpeed, Time.deltaTime * changeSpeed, 0f);
            yield return null;
        }
    }
    IEnumerator FadeOut(float fadeInLength, int imageNum)
    {

        if (fadeInLength < 0.1f)
        {
            fadeInLength = 0.1f;
        }
        float changeSpeed = 1f / fadeInLength;
        while (imageList[imageNum].color.r > 0 && imageList[imageNum].color.b > 0 && imageList[imageNum].color.g > 0)
        {
            //print(imageList[imageNum].color.r);
            imageList[imageNum].color -= new Color(Time.deltaTime * changeSpeed, Time.deltaTime * changeSpeed, Time.deltaTime * changeSpeed, 0f);
            yield return null;
        }
    }

}
