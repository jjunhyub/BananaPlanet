using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFold : MonoBehaviour {
    public Image menuBar;
    public float foldingSpeed;

    bool checker;
    Vector3 temp, pos1, pos2;
	// Use this for initialization
	void Start () {
        checker = true;
        temp = menuBar.transform.position;
        pos1 = menuBar.transform.position;
        pos2 = new Vector3(-10530f, 723f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MenuFolding()
    {
        if (checker)
        {
            StartCoroutine(Fold(foldingSpeed));
            checker = !checker;
        }
        else if (!checker)
        {
            StartCoroutine(UnFold(foldingSpeed));
            checker = !checker;
        }
    }
    IEnumerator Fold(float foldingLength)
    {
        if (foldingLength < 0.1f)
        {
            foldingLength = 0.1f;
        }
        while (menuBar.transform.position.x>-10530f)
        {
            temp.x -= foldingLength * Time.deltaTime;
            transform.position = temp;
            yield return null;
        }
        menuBar.transform.position = pos2;
    }
    IEnumerator UnFold(float foldingLength)
    {
        if (foldingLength < 0.1f)
        {
            foldingLength = 0.1f;
        }
        while (menuBar.transform.position.x < -4800f)
        {
            temp.x += foldingLength * Time.deltaTime;
            menuBar.transform.position = temp;
            yield return null;
        }
        menuBar.transform.position = pos1;
    }
}
