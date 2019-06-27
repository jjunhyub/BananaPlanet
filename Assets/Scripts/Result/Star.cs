using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image Getstar;
    public Image effect;

    int checker;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator StarCollect()
    {
        float t = 0 , s = 0;
        while(s<1f)
        {
            t += Time.deltaTime;
            s = t * t * t * t * t * t * t * t;
            Getstar.transform.localScale = new Vector3(s, s, 1);
            yield return null;
        }
        Getstar.transform.localScale = new Vector3(1, 1, 1);
        effect.gameObject.SetActive(true);
    }
    public void starStart()
    {
        StartCoroutine(StarCollect());
    }
}
