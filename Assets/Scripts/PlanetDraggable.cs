using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDraggable : MonoBehaviour {
    [HideInInspector]
    public bool dragging;

    public TargetImageList targetImageList;
    public BoolControl_GM gm;

    GameObject draggingObject;
    SpriteRenderer sr;
    Planet planet;


    // Use this for initialization
    void Start () {
    } 

	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(!gm.planetDisposeEnd)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 10000f))
                {
                    if (hit.collider.transform.tag == "MovablePlanet")
                    {
                        draggingObject = hit.collider.gameObject;
                        sr = draggingObject.GetComponent<SpriteRenderer>();
                        sr.color = new Color(1f, 1f, 1f, 0.7f);
                        dragging = true;
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (dragging)
                {
                    Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    tmp.z = 0;
                    draggingObject.transform.position = tmp;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                //planet = draggingObject.GetComponent<Planet>();
                //OrbitField selfOrbitField = planet.GetComponent<OrbitField>();
                if(draggingObject!=null)
                {
                    planet = draggingObject.GetComponent<Planet>();
                    OrbitField selfOrbitField = planet.GetComponent<OrbitField>();
                    GameObject[] planetArray = GameObject.FindGameObjectsWithTag("MovablePlanet");
                    foreach (GameObject i in planetArray)
                    {

                        OrbitField orbitField = i.GetComponent<OrbitField>();
                        float temp = orbitField.dist(i.transform.position, planet.transform.position);
                        if (temp != 0 && temp < orbitField.orbitRadius + selfOrbitField.orbitRadius)
                        {
                            int a = planet.planetNum;
                            targetImageList.targetImages[a - 1].planetCount--;
                            targetImageList.targetImages[a - 1].TargetLeftText.text = "x" + (targetImageList.targetImages[a - 1].planetNum - targetImageList.targetImages[a - 1].planetCount);
                            Destroy(draggingObject);
                            dragging = false;
                            break;
                        }
                    }
                }
               
                if (dragging)
                {
                    if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > 3000) //임시 처리 방편임(좋은 방법을 찾고싶다)
                    {
                        
                        int a = planet.planetNum;
                        targetImageList.targetImages[a - 1].planetCount--;
                        targetImageList.targetImages[a - 1].TargetLeftText.text = "x" + (targetImageList.targetImages[a - 1].planetNum - targetImageList.targetImages[a - 1].planetCount);
                        Destroy(draggingObject);
                        dragging = false;
                    }
                    else
                    {
                        sr.color = new Color(1f, 1f, 1f, 1f);
                        dragging = false;
                    }
                }
            }
        }
    }
}
