using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {
    public Image Cross;
    bool checker = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ImageChange()
    {
        checker = !checker;
        Cross.gameObject.SetActive(checker);
    }
}
