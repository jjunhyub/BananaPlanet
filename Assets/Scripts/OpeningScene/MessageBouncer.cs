using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBouncer : MonoBehaviour {
    public List<Image> messageList = new List<Image>();
    public float movingSpeed;

    float t = 3;
	// Use this for initialization
	void Start ()
    {

    }	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if(t>4f) //몇 초에 1사이클인지
        {
            StartCoroutine(MessageJump());
            t = 0;
        }
	}
    IEnumerator MessageJump()
    {
        for(int i=0;i<messageList.Count;i++)
        {
            StartCoroutine(Jump(i));
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Jump(int i)
    {
        Vector3 temp = messageList[i].transform.position;
        float k = temp.y;


        while (temp.y- k <= 500f)
        {
            temp.y += Time.deltaTime * movingSpeed;
            messageList[i].transform.position = temp;
            yield return null;
        }

        k += 500;
        temp.y = k;
        messageList[i].transform.position = temp;

        //yield return new WaitForSeconds(0.1f);

        k -= 500f;

        while (temp.y - k >= 0f)
        {
            temp.y -= Time.deltaTime * movingSpeed;
            messageList[i].transform.position = temp;
            yield return null;
        }

        temp.y = k;
        messageList[i].transform.position = temp;
    }
}
