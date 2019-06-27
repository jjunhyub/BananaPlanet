using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChange : MonoBehaviour
{
    public Image black;
    public string worldString;
    public string stageString;
    string worldName;
     void Start()
    {
    }
    public void Update()
    {
    }
    public void ChangeScene()
    {
        worldName = worldString + stageString;
        StartCoroutine(Fading(worldName));
    }
    IEnumerator Fading(string scenename)
    {
        black.gameObject.SetActive(true);
        float b = 0;
        while(black.color.a<=1)
        {
            b += 0.02f;
            black.color = new Color(1, 1, 1, b);
            yield return null;
        }
        black.color = new Color(1, 1, 1, b);
        b = 1;
        SceneManager.LoadScene(scenename);
    }
    public void ReturnGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}