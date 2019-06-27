using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlanetRotator : MonoBehaviour, IPointerDownHandler {
    public Image rotator;
    public SceneChange sceneChange;
    public TopBar topBar;
    public LeftBarListManager leftBarListManager;
    public int planetNum;
    public int stagesNumber;
    public List<StarManager> starManager = new List<StarManager>();
    public string world;
    int star;
	// Use this for initialization
	void Start () {
        star = planetNum * 10 + 1;
	}

    public void OnPointerDown(PointerEventData eventData) //이 스크립트가 들어있는 ui가 눌러졌을때 발동한다.
    {
        float x, y;
        RectTransform rt = rotator.GetComponent<RectTransform>();
        RectTransform rt_2 = GetComponent<RectTransform>();
        rotator.transform.position = gameObject.transform.position;
        x = rt_2.rect.height +  0f;
        y = rt_2.rect.height + 50f;
        rt.sizeDelta = new Vector2(x, y);
        sceneChange.worldString = world;
        topBar.planetNumber = planetNum;
        leftBarListManager.worldNumber = planetNum;
        leftBarListManager.worldStageNum = stagesNumber;
        for(int i = 0;i<starManager.Count;i++)
        {
            starManager[i].stageNum = star+i;
        }
    }
    public void ImsiSelect()
    {
        float x, y;
        RectTransform rt = rotator.GetComponent<RectTransform>();
        RectTransform rt_2 = GetComponent<RectTransform>();
        rotator.transform.position = gameObject.transform.position;
        x = rt_2.rect.height + 0f;
        y = rt_2.rect.height + 50f;
        rt.sizeDelta = new Vector2(x, y);
        sceneChange.worldString = world;
        topBar.planetNumber = planetNum;
        leftBarListManager.worldNumber = planetNum;
        leftBarListManager.worldStageNum = stagesNumber;
        for (int i = 0; i < starManager.Count; i++)
        {
            starManager[i].stageNum = star + i;
        }
    }
    // Update is called once per frame
    void Update () {
	}
}
