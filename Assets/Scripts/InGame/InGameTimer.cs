using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour {

    public List<Image> numberImages = new List<Image>();
    public Image minute_1, minute_2, second_1, second_2;
    public Player player;

    int minute__1, minute__2, second__, second__2;
    public int timer = 0;
    public float t = 0;

    void Start()
    {
        player.GameEnd = true;
    }

    // Update is called once per frame 
    void Update()
    {
        if(!player.GameEnd)
        {
            t += Time.deltaTime; //매 프레임마다 프레임 시간을 더하고 있으니까 t는 '초'가 된다.
            if (t > 1f)
            {
                timer += 1;
                t = 0;
                TimeChange(timer);
            }
        }
    }

    public void TimeChange(int timer)
    { 
        int a, b, c, d, e, f;
        e = timer / 60;
        f = timer % 60;
        a = e / 10;
        b = e % 10;
        c = f / 10;
        d = f % 10;
        minute_1.sprite = numberImages[a].sprite;
        minute_2.sprite = numberImages[b].sprite;
        second_1.sprite = numberImages[c].sprite;
        second_2.sprite = numberImages[d].sprite;
    }
    public void TimeReset()
    {
        minute_1.sprite = numberImages[0].sprite;
        minute_2.sprite = numberImages[0].sprite;
        second_1.sprite = numberImages[0].sprite;
        second_2.sprite = numberImages[0].sprite;
    }
}
