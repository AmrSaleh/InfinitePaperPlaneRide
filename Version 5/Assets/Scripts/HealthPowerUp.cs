using UnityEngine;
using System.Collections;

public class HealthPowerUp : MonoBehaviour {

	public GameObject healthEffect;

	PlaneControl planeScriptObject;

	public int gainedHealth = 20;
	private GameObject healthFKT;
	private bool isRunning = false;

	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();

	}
	
	public void startEffect ()
	{


		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		

		
		healthFKT = Instantiate (healthEffect, transform.position, transform.rotation)as GameObject;

		planeScriptObject. adjustCurrentHealth(gainedHealth);
		//			makeEffects();

		
		
		
		
	}
	
	void Update ()
	{
		if(healthFKT!= null)
			healthFKT.transform.position = transform.position;
			

	}
}
