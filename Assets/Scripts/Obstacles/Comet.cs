using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comet : MonoBehaviour
{
    public Vector3 startPoint, endPoint;
    public ParticleSystem explosion;
    public Shooter shooter;
    [HideInInspector]
    public bool start = true, end = false;
    public List<Vector3> movingPoints = new List<Vector3>();
    public List<bool> boolPoints = new List<bool>();
    public float cometSpeed = 10,waitingTime;
    public Image comet1, comet2;
    private float t = 0f;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        transform.position = startPoint;
        StartCoroutine(CometChange());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("start :" + start);
        Debug.Log("end   :" + end);
        if (transform.position == startPoint)
        {
            start = true;
            end = false;
        }//시작 지점 도착
        if (transform.position == endPoint)
        {
            start = false;
            end = true;
        }//끝 지점 도착

        if (start && !end)
        {
            t += Time.deltaTime;
            if (t * 3f >= waitingTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint, cometSpeed);
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x) * Mathf.Rad2Deg);
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x)*Mathf.Rad2Deg);
                Debug.Log("기울기 : "+Mathf.Atan2(startPoint.y - endPoint.y, startPoint.x - endPoint.x) * Mathf.Rad2Deg);
            }
        }
        if (!start && end)
        {
            transform.position = startPoint;
            t = 0f;
        }
    }
    IEnumerator CometChange()
    {
        for(int i = 0; i<500;i++)
        {
            sr.sprite = comet1.sprite;
            yield return new WaitForSeconds(0.2f);
            sr.sprite = comet2.sprite;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void ResetComet()
    {
        transform.position = startPoint;
        start = true;
        end = false;
        t = 0;
    }
}
