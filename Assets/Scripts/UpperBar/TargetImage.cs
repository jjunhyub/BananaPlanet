using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TargetImage : MonoBehaviour, IPointerDownHandler
{
    public Canvas mainCanvas;
    public int planetId;  //행성을 구별할 수 있는 ID값 (도감넘버)
    public int planetNum; //그 스테이지에서 배치할 수 있는 행성의 수
    [HideInInspector]
    public int planetCount = 0; //몇개를 끌어다가 썼는지

    public PlanetMaster planetMaster;
    public PlanetDraggable planetDraggable;
    public Text TargetLeftText;
    public BoolControl_GM gm;
    [HideInInspector]
    public Planet planet;

    Vector3 touch;
    GameObject clonePlanet;


    void Start()
    {
        TargetLeftText.text = "x" + (planetNum - planetCount);
    }
    public void OnPointerDown(PointerEventData eventData) //이 스크립트가 들어있는 ui가 눌러졌을때 발동한다.
    {
        if(!gm.planetDisposeEnd)
        {
            //Debug.Log("asdadfasdfasdfasdfasdfasf");
            if (planetCount < planetNum)
                CallPlanet(planetId);
        }
    }
    public void CallPlanet(int planetID)
    {
        touch.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        touch.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        touch.z = 0;
        clonePlanet = Instantiate(planetMaster.planetMasterList[planetId - 1], touch, Quaternion.identity,mainCanvas.transform);
        planet = clonePlanet.GetComponent<Planet>();
        planet.planetMovabool = true;
        planetCount++;
        TargetLeftText.text = "x" + (planetNum - planetCount);
        StartCoroutine(FollowMouse());
    }
    void Update()
    {
        if (planet != null && planet.planetMovabool&&Input.GetMouseButtonUp(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > 3000)//임시 처리 방편임(좋은 방법을 찾고싶다)
            {
                //Destroy(clonePlanet);
                //planetCount--;
                //TargetLeftText.text = "x" + (planetNum - planetCount);
            }
            else
            {
                planet.planetMovabool = false;
                clonePlanet.tag = "MovablePlanet";
                planet = null;
            }
        }
            
    }
    IEnumerator FollowMouse()
    {
        while (planet!=null&&planet.planetMovabool)
        {
            Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tmp.z = 0;
            clonePlanet.transform.position = tmp;
            yield return null;
        }
    }
}
