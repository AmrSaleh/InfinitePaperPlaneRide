using UnityEngine;
using System.Collections;

public class RainEffect : MonoBehaviour {

	public GameObject rainEffect;
	public GameObject hitCloud;
	public GameObject blackScreen;
	PlaneControl planeScriptObject;

	
	//	private float startTime;
	private float endTime;
	public float duration = 5.0f;
	private bool isRunning = false;
	// Use this for initialization
	private GameObject rain,hit,black;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
	
	}
	
	public void startEffect ()
	{
		if (isRunning) {
			return;
		}
		isRunning = true;
		
		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
		//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
		
		rain = Instantiate (rainEffect) as GameObject;
		black = Instantiate (blackScreen) as GameObject;
		hit = Instantiate (hitCloud, transform.position,transform.rotation) as GameObject;

		planeScriptObject.raining = true;

		

		//			makeEffects();
		endTime = Time.time + duration;
		
		
		
		
	}
	
	public void endPowerup ()
	{
		
		isRunning = false;
		planeScriptObject.raining = false;
		Destroy (rain);
		Destroy (black);

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > endTime && isRunning) {
			endPowerup ();
		} 
	}
}
