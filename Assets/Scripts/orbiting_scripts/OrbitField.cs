using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class OrbitField : MonoBehaviour {

	//------------------------------------------------------

	public float orbitRadius;
	public bool clockwise = true;
	public float orbitPeriod = 3f;
	public bool blackHole = false;
	[Tooltip("get smaller get faster")]
	public float blackHolePercent = 99.999f;
	public bool drawOrbit;
	[HideInInspector]
	public GameObject orbitingObject;
	public GameObject pointingObject;


	private float orbitProgress = 0f;
    private BoolControl_GM gm;
	public bool isOutCircle=true,orbitActive = false;
	private Rigidbody2D rb;
	private float initialOrbitSize;
	private Circle orbitPath;
	private LineRenderer lr;
	private IEnumerator circleCoroutine;
    public float t;

	[Range(3,36)]
	public int segments = 36;



	//------------------------------------------------------

	//orbit renederer
	void Awake(){
		lr = GetComponent<LineRenderer>();
		circleCoroutine = AnimateOrbit ();

	}
	void CalculateEllipse(){
		Vector3[] points = new Vector3[segments + 1];
		for (int i = 0; i < segments; i++) {
			Vector2 position2D = orbitPath.Evaluate ((float)i / (float)segments);
			points [i] = new Vector3 (position2D.x+this.transform.position.x, position2D.y + this.transform.position.y,-0.1f);
		}
		points [segments] = points [0];
		lr.positionCount = segments + 1;
		lr.SetPositions (points);
	}

	//------------------------------------------------------

	//initial	
	void Start()
	{
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<BoolControl_GM>();
        orbitingObject = GameObject.FindGameObjectWithTag ("Player");
		pointingObject = GameObject.FindGameObjectWithTag ("Pointer");
		rb = orbitingObject.GetComponent<Rigidbody2D> ();

		orbitPath = new Circle (orbitRadius);
		initialOrbitSize = orbitPath.xAxis;


	}

	public float dist(Vector3 a, Vector3 b){
		float c = a.x - b.x;
		float d = a.y - b.y;
		return Mathf.Sqrt (d * d + c * c);
	}

	//when clicked nothing
	void Clicked()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log (hit.collider.gameObject.name);
		} else if(orbitActive){
			Shoot ();
		}
	}

	//shoots player from orbit
	void Shoot()
	{
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayOrbitShoot();
        print ("Shoooooooooooooooooooooooooot");
		orbitActive = false;
	}

	//Calls on every frame
	void Update(){
        Debug.Log("isOutCircle : "+isOutCircle);
        Debug.Log("orbitActive : "+orbitActive);
		if (drawOrbit)
			CalculateEllipse ();
		//if(dist (orbitingObject.transform.position, this.transform.position)>

		if (initialOrbitSize+10 < dist (orbitingObject.transform.position, this.transform.position)) {
			isOutCircle = true;
			orbitPath.xAxis = initialOrbitSize;
			orbitPath.yAxis = initialOrbitSize;
		}
        
		if (gm.planetDisposeEnd&&isOutCircle && orbitActive == false && orbitingObject != null 
			&& dist (orbitingObject.transform.position, this.transform.position) <= orbitPath.xAxis) {
            Debug.Log("acting");
			orbitActive = true;
			isOutCircle = false;
			orbitProgress = Mathf.Atan2 (orbitingObject.transform.position.y - this.transform.position.y,
				orbitingObject.transform.position.x - this.transform.position.x) / (Mathf.PI * 2);
			StartCoroutine (AnimateOrbit());
		}

        else if(Input.GetMouseButtonDown(0)&&orbitActive){
			
				Clicked();
			
		}

	}

	//sets players position on orbit
	void SetOrbitingObjectPosition(){
		Vector2 orbitPos = orbitPath.Evaluate (orbitProgress);
		orbitingObject.transform.position = new Vector3 ((orbitPos.x+this.transform.position.x), orbitPos.y+this.transform.position.y, 0.1f);
	}

	//make player orbit
	IEnumerator AnimateOrbit(){
		//SpriteRenderer SR = pointingObject.GetComponent<SpriteRenderer> ();
		//SR.enabled = !SR.enabled;
		rb.velocity = Vector2.zero;
		Vector2 v2;
        float circleLine = 2 * Mathf.PI * orbitRadius;
        orbitPeriod = circleLine / (orbitingObject.GetComponent<Player>().playerSpeed/t);
		if (orbitPeriod < 0.1f) {
			orbitPeriod = 0.1f;
		}
		float OrbitSpeed = 1f / orbitPeriod;
		while (orbitActive) {
            Debug.Log("나오면 안된다");
			
			if (blackHole) {
				orbitPath.Shrink (blackHolePercent);
				//print (orbitPath.xAxis);
				//OrbitSpeed *= 100f / blackHolePercent;
			}
			v2 = orbitingObject.transform.position - this.transform.position;
			if (clockwise) {
				v2 = new Vector2 (-v2.y, v2.x);
			} else {
				v2 = new Vector2 (v2.y, -v2.x);
			}
			orbitingObject.transform.up = new Vector3 (v2.x, v2.y, 0);

			if(clockwise)orbitProgress += Time.deltaTime * OrbitSpeed;
			else orbitProgress -= Time.deltaTime * OrbitSpeed;
			orbitProgress %= 1f;
			SetOrbitingObjectPosition ();
			yield return null;
		}
		v2 = orbitingObject.transform.position - this.transform.position;

		if (clockwise) {
			v2 = new Vector2 (-v2.y, v2.x);
		} else {
			v2 = new Vector2 (v2.y, -v2.x);
		}
		rb.velocity = v2.normalized* orbitingObject.GetComponent<Player>().playerSpeed;
		//SR.enabled = !SR.enabled;
	}
    public void StopOrbitActive()
    {
        Debug.Log("코루틴이 꺼지고있다");
        StopCoroutine("AnimateOrbit");
    }


	
}
