using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject resultPage;
    public Shooter shooter;
    public BoolControl_GM gm;
    public float banana_X, banana_Y, banana_Z, playerSpeed = 50000f;
    public bool GameEnd,GameReset;
    public GameObject startButton;
    public InGameTimer inGameTimer;
    public GameObject explosion1, explosion2, explosion3;
    public StarCollectPlayerPrefs starCollectPlayerPrefs;
    public List<GameObject> gorillasColorChange = new List<GameObject>();
    Vector3 tempVec;


    Rigidbody2D rb2D;
    void Start()
    {
        transform.position = shooter.transform.position;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>();
        rb2D  =  GetComponent<Rigidbody2D>();
        GameReset = false;
    }

    void Update()
    {
		if (rb2D.velocity != Vector2.zero) {
			Vector3 tmp = Vector3.zero;
			tmp.x = rb2D.velocity.x;
			tmp.y = rb2D.velocity.y;
			transform.up = tmp;
		}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            GameEnd = true;
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayArrive();
            //gameObject.SetActive(false);  
            StartCoroutine(BananaGetSmall());
            StartCoroutine(ResultManager());
            //ResetBanana();
            GorillaChange();
            Debug.Log("qwe");
        }
        if (collision.tag == "Wall"|| collision.tag == "Comet")
        {
            //Instantiate(explosion,transform.position,Quaternion.identity); //particleSystem없애야할듯
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayDestroy();
            tempVec = transform.position;
            StartCoroutine("BananaExplosion");
            ResetBanana();
        }
    }
    
    public void ResetBanana()
    {
        GameObject[] movablePlanetArray = GameObject.FindGameObjectsWithTag("MovablePlanet");
        GameObject[] planetArray = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject i in planetArray)
        {
            i.GetComponent<OrbitField>().StopOrbitActive();
        }
        foreach (GameObject i in movablePlanetArray)
        {
            i.GetComponent<OrbitField>().StopOrbitActive();
        }
        Debug.Log("reset~!");
        rb2D.velocity = Vector2.zero;
        transform.position = shooter.transform.position;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        shooter.swipeOK = false;
        GameResetTrue();
        GameEndTrue();
        gm.PlanetDisposeEndFalse();
        startButton.SetActive(true);
        shooter.MainCanvasFalse();
        shooter.SwipeOKfalse();
        inGameTimer.t = 0;
        inGameTimer.timer = 0;
        inGameTimer.TimeReset();
        transform.position = shooter.transform.position;
        starCollectPlayerPrefs.eatingStarList[0].transform.position = starCollectPlayerPrefs.star1Position;
        starCollectPlayerPrefs.eatingStarList[1].transform.position = starCollectPlayerPrefs.star2Position;
        starCollectPlayerPrefs.eatingStarList[2].transform.position = starCollectPlayerPrefs.star3Position;
        starCollectPlayerPrefs.starNumber = 0;
        //gameObject.SetActive(false);
    }
    IEnumerator ResultManager()
    {
        resultPage.SetActive(true);
        yield return null;
    }
    public void GameEndTrue()
    {
        GameEnd = true;
    }
    public void GameEndFalse()
    {
        GameEnd = false;
    }
    public void GameResetTrue()
    {
        GameReset = true;
    }
    public void GameResetFalse()
    {
        GameReset = false;
    }
    IEnumerator BananaGetSmall()
    {
        while (transform.localScale.x > 5f)
        {
            transform.localScale -= new Vector3(5f, 5f, 5f);
            yield return null;
        }
        rb2D.velocity = Vector2.zero;
        StopCoroutine(BananaGetSmall());
    }
    IEnumerator BananaExplosion()
    {
        StartCoroutine(ImageBlink(explosion1));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(ImageBlink(explosion2));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(ImageBlink(explosion3));
    }
    IEnumerator ImageBlink(GameObject g)
    {
        g.transform.position = tempVec;
        g.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        g.SetActive(false);
    }
    void GorillaChange()
    {
        foreach(GameObject i in gorillasColorChange)
        {
            i.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
