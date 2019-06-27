using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : MonoBehaviour {
    public List<Vector3> movingPoints = new List<Vector3>();
    public List<bool> boolPoints = new List<bool>();
	private GorillaRenderer gR;
    public float gorillaSpeed=10;
    [HideInInspector]
    public bool start=true, end=false;
    // Use this for initialization
    void Start () {
        transform.position = movingPoints[0];
		gR= GetComponent<GorillaRenderer> ();
		gR.lr.positionCount = movingPoints.Count;
		gR.lr.SetPositions (movingPoints.ToArray ());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movingPoints[0])                          //시작 지점 도착
        {
            start = true;
            end = false;
        }
        if (transform.position == movingPoints[movingPoints.Count - 1])     //끝 지점 도착
        {
            start = false;
            end = true;
        }
        for (int i = 0; i < movingPoints.Count; i++)
        {
            if(transform.position==movingPoints[i])
            {
                for (int j = 0; j < boolPoints.Count; j++)
                    boolPoints[j] = false;
                boolPoints[i] = true;
            }
        }
        if (start && !end)
        {
            for(int i=0;i<boolPoints.Count-1;i++)
            {
                if(boolPoints[i])
                    transform.position = Vector3.MoveTowards(transform.position, movingPoints[i+1], gorillaSpeed);
            }
        }
        if (!start && end)
        {
            for (int i = 1; i < boolPoints.Count; i++)
            {
                if (boolPoints[i])
                    transform.position = Vector3.MoveTowards(transform.position, movingPoints[i - 1], gorillaSpeed);
            }
        }
    }
}
