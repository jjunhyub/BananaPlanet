using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LeftBarUnderLine : MonoBehaviour, IPointerDownHandler
{
    public Image redLine;
    public int redLineY;
    public SceneChange sceneChange;
    public string stageNum;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
    public void OnPointerDown(PointerEventData eventData) //이 스크립트가 들어있는 ui가 눌러졌을때 발동한다.
    {
        redLine.transform.localPosition= new Vector3(-55, redLineY, 0);
        sceneChange.stageString = stageNum;
    }
    public void ImsiSelect()
    {
        redLine.transform.localPosition = new Vector3(-55, redLineY, 0);
        sceneChange.stageString = stageNum;
    }
    public void LineUp()
    {
        redLine.transform.localPosition = new Vector3(-55, 375, 0);
    }
}
