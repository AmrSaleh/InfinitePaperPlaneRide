using UnityEngine;
using System.Collections;

public class speedPowerUp : MonoBehaviour
{
//
		public GameObject shieldEffect;
		public GameObject speedEffect;
		PlaneControl planeScriptObject;
		ScrollingScript backGroundScrollScript;
		private float oldBackGroundSpeed;
		private int oldEnemiesSpeed, oldCoinSpeed;
		private int oldBottleSpeed;
		private int oldDragonSpeed;
		private float oldCoinSleep;
		private int oldScoreIncreaseRatio;
		public int newScoreIncreaseRatio = 3;
		public int newEnemySpeed = 1000;
		public int newCoinSpeed = 1000;
		public float newCoinSleep = 0.04f;
		public int newBottleSpeed = 1000;
		public int newDragonSpeed = 500;
		public float newBgSpeed = 5.0f;

//	private float startTime;
		private float endTime;
		public float duration = 5.0f;
		public bool isRunning = false;
		// Use this for initialization
		private GameObject shield, speed;

		void Start ()
		{
				planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
				backGroundScrollScript = GameObject.Find ("Sky Quad").GetComponent<ScrollingScript> ();
		}

		public void startEffect ()
		{
				if (isRunning) {
						return;
				}
				isRunning = true;
			
//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
			
//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
					
				shield = Instantiate (shieldEffect, transform.position, transform.rotation)as GameObject;
				speed = Instantiate (speedEffect, transform.position, transform.rotation)as GameObject;
				oldBackGroundSpeed = backGroundScrollScript.Speed;
				oldCoinSpeed = planeScriptObject.coinSpeed;
				oldCoinSleep = planeScriptObject.coinSleep;
				oldEnemiesSpeed = planeScriptObject.InitialEnemySpeed;
				oldDragonSpeed = planeScriptObject.dragonSpeed;
				oldBottleSpeed = planeScriptObject.powerUpSpeed;
				oldScoreIncreaseRatio = planeScriptObject.scoreIncreaseRatio;

				planeScriptObject.invincible = true;
				backGroundScrollScript.Speed = newBgSpeed;
				planeScriptObject.coinSpeed = newCoinSpeed;
				planeScriptObject.coinSleep = newCoinSleep;
				planeScriptObject.InitialEnemySpeed = newEnemySpeed;
				planeScriptObject.dragonSpeed = newDragonSpeed;
				planeScriptObject.powerUpSpeed = newBottleSpeed;
				planeScriptObject.scoreIncreaseRatio = newScoreIncreaseRatio;
//			makeEffects();
				endTime = Time.time + duration;

				

				
		}

		public void endPowerup ()
		{

				isRunning = false;
				backGroundScrollScript.Speed = oldBackGroundSpeed;
				planeScriptObject.coinSpeed = oldCoinSpeed;
				planeScriptObject.coinSleep = oldCoinSleep;
				planeScriptObject.InitialEnemySpeed = oldEnemiesSpeed;
				planeScriptObject.invincible = false;

				planeScriptObject.dragonSpeed = oldDragonSpeed;
				planeScriptObject.powerUpSpeed = oldBottleSpeed;
				planeScriptObject.scoreIncreaseRatio = oldScoreIncreaseRatio;
				

		Debug.Log ("abl el destroy");
				Destroy (shield);
				Destroy (speed);
		Debug.Log ("ba3d el destroy");
		}

		// Update is called once per frame
		void Update ()
		{
				if (Time.time > endTime && isRunning) {
						endPowerup ();
				} else if (isRunning) {
						shield.transform.position = transform.position;
						speed.transform.position = new Vector2 (transform.position.x - 1, transform.position.y);
				}
		}
}
