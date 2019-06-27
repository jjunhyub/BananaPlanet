using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : MonoBehaviour {
    public Image black;
    public isPage ispage;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(ispage.loadingEnd)
        {
            ispage.loadingEnd = false;
            StartCoroutine(InGameFading());
        }
		
	}
    IEnumerator InGameFading()
    {
        black.gameObject.SetActive(true);
        float b = 1;
        while (black.color.a >= 0)
        {
            b -= 0.02f;
            black.color = new Color(1, 1, 1, b);
            yield return null;
        }
        b = 0;
        black.color = new Color(1, 1, 1, b);
        black.gameObject.SetActive(false);
    }
}
