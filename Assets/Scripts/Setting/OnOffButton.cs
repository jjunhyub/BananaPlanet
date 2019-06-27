using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnOffButton : MonoBehaviour,IPointerDownHandler {
    public Vector3 point1, point2;
    public Image movingButton;
    bool soundOnOff;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pointerDown");
        if (!soundOnOff)
        {
            movingButton.rectTransform.position = point2;
            soundOnOff = !soundOnOff;
        }
        else if (soundOnOff)
        {
            movingButton.rectTransform.position = point1;
            soundOnOff = !soundOnOff;
        }
    }

    // Use this for initialization
    void Start ()
    {
        soundOnOff = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
