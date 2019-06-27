using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Shooter : MonoBehaviour
{
    private Vector2 startTouch, currentTouch, endTouch;
    public Vector3 slingVector,emptyVector2, sumVector,temp;
    public Vector3[] arr;
    public UnityEngine.GameObject banana, shooter, lineRenderer;


    Rigidbody2D rb;
    LineRenderer lr;

    [HideInInspector]
    public bool mainCanvas = true; //State Boolean
    public bool swipeOK, isShoot = false, gravityOK = false, gameStart = false;
    public float force, cameraSpeed, forceConstant;
    public GameObject directionPlanet; 

    Rigidbody2D rb2d;
    // Use this for initialization

    void Start()
    {
        lr = lineRenderer.GetComponent<LineRenderer>();
        rb = banana.GetComponent<Rigidbody2D>();
        swipeOK = false;
        banana.transform.position = shooter.transform.position;
        emptyVector2 = shooter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("swipeOK : " + swipeOK);
        Debug.Log("mainCanvas : " + mainCanvas);
        if(mainCanvas)
        {
            if (swipeOK)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameStart = true;
                    gravityOK = false;
                    startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    temp = banana.transform.position;
                    currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("button");
                    banana.transform.position = temp;
                    rb.velocity = (Vector2.zero);
                    gravityOK = false;
                    currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                   // Debug.Log("slingVector : " + slingVector.magnitude);
                    slingVector = startTouch - currentTouch;
                    if (slingVector.magnitude > 500f)
                    {
                        banana.transform.up = slingVector;
                        sumVector = banana.transform.position + slingVector * 1000f;
                        Vector3[] arr = { banana.transform.position, sumVector };
                        lr.SetPositions(arr);
                        directionPlanet.transform.up = slingVector;
                    }
                }

                else if (Input.GetMouseButtonUp(0))
                {
                    if (slingVector.magnitude > 500f)
                    {
                        Debug.Log("up");
                        sumVector = emptyVector2;
                        Vector3[] arr = { banana.transform.position, banana.transform.position };
                        lr.SetPositions(arr);
                        isShoot = true;
                        gravityOK = true;
                        endTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        slingVector = startTouch - endTouch;
                        force = Mathf.Sqrt((slingVector.x) * (slingVector.x) + (slingVector.y) * (slingVector.y));
                        swipeOK = false;
                        StartCoroutine(BananaGetBig());
                    }
                }
            }
        }

        if (isShoot)
        {
            Debug.Log("뭔가 이상함");
            isShoot = false;
            rb.velocity = Vector3.Normalize(slingVector) * banana.GetComponent<Player>().playerSpeed; // 안에 *force 곱해주면 당긴 길이에 비례하여 속도
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayShoot();
        }
    }
    public void SwipeOKtrue()
    {
        StartCoroutine(SwipeOKKTrue());
    }
    public void SwipeOKfalse()
    {
        StartCoroutine(SwipeOKKFalse());
    }
    IEnumerator SwipeOKKTrue()
    {
        yield return new WaitForSeconds(0.1f);
        swipeOK =true;
    }
    IEnumerator SwipeOKKFalse()
    {
        yield return new WaitForSeconds(0.1f);
        swipeOK = false;
    }
    IEnumerator BananaGetBig()
    {
        while(banana.transform.localScale.x<30)
        {
            banana.transform.localScale += new Vector3(2f, 2f, 2f);
            yield return null;
        }
        StopCoroutine(BananaGetBig());
    }

    //진짜 안좋은 코드이지만 당장 해결방법이 쉽게 떠오르지 않아서 임시적으로 만들어 놓은  코드.
    //원래에는 start버튼을 누르면 bool값을 바꿔서 swipeOK이후가 진행되어야 하는데 버튼을 누르는 순가 mouseButtonUp이 눌려버려서 바로 날라가버린다.
    //임시 해결 방법 : 코루틴을 써서 1초뒤에 발동시켜서 버튼이 눌리면서 mouseButtonUp이 되는것을 막는다.
    public void MainCanvasFalse()
    {
        mainCanvas = false;
    }
    public void MainCanvasTrue()
    {
        mainCanvas = true;
    }
}