using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectPlayerPrefs : MonoBehaviour {
    public List<GameObject> eatingStarList = new List<GameObject>();
    public GameObject player;
    public StarOrder starOrder;
    public float distance;
    public int stageNumber;
    public int starNumber = 0;
    public Vector3 star1Position, star2Position, star3Position;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("WorldStageNumberPlayerPrefs" + stageNumber, 0); //임시적으로 게임을 초기화하기 위한 수단 (초기화 한번해주고 주석처리 해주어야한다.)
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in eatingStarList)
        {
            if (Vector3.Distance(player.transform.position, i.transform.position) < distance)
            {
                GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayStar();
                i.transform.position = new Vector3(0, 9000, 0);
                starNumber++;
                starOrder.starCollected = starNumber;
                Debug.Log("starNumber : " + starNumber);
                if (PlayerPrefs.GetInt("WorldStageNumberPlayerPrefs")<starNumber)
                {
                    PlayerPrefs.SetInt("WorldStageNumberPlayerPrefs" + stageNumber, starNumber);
                }
            }
        }
    }
}
