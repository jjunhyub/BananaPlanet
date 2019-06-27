using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftBarListManager : MonoBehaviour {
    public List<GameObject> worldStage = new List<GameObject>(); //6까지 전부 받아야 한다.
    public List<Image> firstImage = new List<Image>();
    public List<Image> worldNumberImage = new List<Image>();
    public List<StarManager> starManagerManager = new List<StarManager>();

    public int worldStageNum;
    public int worldNumber;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < worldStageNum; i++)
        {
            worldStage[i].SetActive(true);
        }
        for (int j = worldStageNum; j < worldStage.Count; j++)
        {
            worldStage[j].SetActive(false);
        }
        for (int i=0;i<worldStageNum;i++)
        {
            Debug.Log("뭔가를 보여드리겠습니다");
            firstImage[i].sprite = worldNumberImage[worldNumber -1].sprite;
        }
		
	}
}
