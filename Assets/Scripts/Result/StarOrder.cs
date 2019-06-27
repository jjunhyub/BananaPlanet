  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarOrder : MonoBehaviour {

    public List<Star> stars = new List<Star>();
    public GameObject stamp;

    public int starCollected;
    public float waitingSecond;
	// Use this for initialization
	void Start () {
        StartCoroutine(starsOrder());
	}
	
	// Update is called once per frame
	void Update () {
	}
    IEnumerator starsOrder()
    {
        for (int i = 0; i < starCollected; i++)
        {
            stars[i].starStart();
            yield return new WaitForSeconds(waitingSecond);
            if(i==starCollected-1)
            {
                //Debug.Log("stamp시작");
                //StartCoroutine(Stamping());
            }
        }

    }
    IEnumerator Stamping()
    {
        yield return new WaitForSeconds(waitingSecond);
        stamp.SetActive(true);
        float t = 1.5f, s = 100;
        while (s > 1f)
        {
            Debug.Log("줄어드는중");
            Debug.Log("" + s);
            t += Time.deltaTime;
            s =100- t*t*t*t*t*t*t*t;
            stamp.transform.localScale = new Vector3(s, s, 1);
            yield return null;
        }
        stamp.transform.localScale = new Vector3(1, 1, 1);
    }
}
