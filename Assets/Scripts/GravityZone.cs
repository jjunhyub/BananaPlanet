using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityZone : MonoBehaviour {
    public Player player;
    public Shooter shooter;
    public SpriteRenderer sr;
    public Color color;
    [HideInInspector]
    public float distance;
    public float gravityRadius;
    public float gravity = -12;
    private float num;

    // Use this for initialization
    void Start () {
        transform.localScale = new Vector3(gravityRadius*0.75f, gravityRadius*0.75f, 1);
    }
	
	// Update is called once per frame
	void Update () {
        sr.color = color;
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (shooter.gameStart)
        {
            if (distance <= gravityRadius)
                shooter.gravityOK = true;
            else
                shooter.gravityOK = false;
            Attract(player.transform);
        }
    }
    public void Attract(Transform body)
    {
        if (shooter.gravityOK)
        {
            Vector3 gravityUp = (body.position - transform.position).normalized;
            Vector3 localUp = body.up;
            num += Time.deltaTime;

            body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity * num);
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f /** Time.deltaTime*/);
        }
    }
}
