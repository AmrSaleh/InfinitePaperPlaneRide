using UnityEngine;
using System.Collections;

public class shootFireBall : MonoBehaviour {

	public GameObject fireBall;
	public GameObject hitEffect;
	public GameObject player;
	PlaneControl planeScriptObject;
	
	
		private float startTime;
	private float endTime;
	public float duration = 0.005f;
	private bool isRunning = false;
	// Use this for initialization
	private GameObject rain,hit,black;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
		endTime = Time.time + duration;
	}
	
	public void startEffect ()
	{
		if (isRunning) {
			return;
		}
		isRunning = true;
		
		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
		//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;


//		rain = Instantiate (rainEffect) as GameObject;
//		black = Instantiate (blackScreen) as GameObject;
		hit = Instantiate (fireBall, transform.position,transform.rotation) as GameObject;
	hit.rigidbody2D.AddForce(-transform.right.normalized * 500);
//		planeScriptObject.raining = true;
		
		
		
		//			makeEffects();
		endTime = Time.time + duration;
		
		
		
		
	}






	public void endPowerup ()
	{
		
		isRunning = false;
//		planeScriptObject.raining = false;
//		Destroy (rain);
		Destroy (hit);
		
		
	}
	Transform target;
	// Update is called once per frame
	int x =0;
	void Update ()
	{
//		if (Time.time > endTime ) {
////			endPowerup();
//			startEffect ();
//		} 


		x++;
		if (x > 100) {
			endPowerup();
			startEffect ();
			x=0;
				}



//		if (planeScriptObject.gameEnded)
//						return;
//		target = GameObject.FindWithTag ("Player").transform;
//	



	}
	bool ss =true;
	void FixedUpdate () {
		
		
		if (planeScriptObject.gameEnded)
			return;
		target = GameObject.FindWithTag ("Player").transform;
		
		Vector3 forwardAxis = new Vector3 (0, 0, -1);
		
		if (transform.position.x > target.position.x + 1) {
						var newRotation = Quaternion.LookRotation (transform.position - target.position, Vector3.up);
						newRotation.x = 0.0f;
						newRotation.y = 0.0f;
						transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 8);
		
//		transform.LookAt (target.position, forwardAxis);
						Debug.DrawLine (transform.position, target.position);
//		transform.eulerAngles = new Vector3 (0, 0, -transform.eulerAngles.z);
//		transform.position -= transform.TransformDirection (Vector2.up) * 5f ;
				} else {
			transform.Rotate(new Vector3(0,0,0.5f));		
		}

		while(ss) {
			startEffect();
			ss= false;
				} 



	}
}
