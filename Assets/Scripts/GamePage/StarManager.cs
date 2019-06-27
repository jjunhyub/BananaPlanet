using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour {

    public int starNum;
    public int stageNum;
    public List<GameObject> starImage = new List<GameObject>();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        starNum = PlayerPrefs.GetInt("WorldStageNumberPlayerPrefs" + stageNum);
        Debug.Log("stageNum : " + stageNum);
        for (int i=0;i<starNum; i++)
        {
            starImage[i].SetActive(true);
        }
        for (int i = starNum; i < starImage.Count; i++)
        {
            starImage[i].SetActive(false);
        }
    }
}
