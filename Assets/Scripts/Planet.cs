using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float gravity = -12;
    public Shooter shooter;
    public GravityZone gravityZone;
    public int planetNum;
    public bool planetMovabool;
    Comet comet;
    GameObject[] cometObject;
    public float planetSize;
    private void Start()
    {
        cometObject = GameObject.FindGameObjectsWithTag("Comet");
    }
    private void Update()
    {
        foreach (GameObject a in cometObject)
        {
            if(Vector3.Distance(a.transform.position,transform.position)<planetSize)
            {
                a.GetComponent<Comet>().ResetComet();
            }
        }
            
    }
}
