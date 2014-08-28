using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour
{
	
	public float speed;
	speedPowerUp speedPowerScript;
	HealthPowerUp healthPowerScript;
	bulletsPowerUp bulletsPowerScript;
	struckByLightning LightningScript;
	RainEffect rainScript;
	public float maxHealth = 100;
	public float currHealth = 100;
	public float healthBarLength;
	private GUIStyle currentStyle = null;
	public GUIStyle LabelStyle;
	public bool gameEnded;
	PoolScript activateBullet;
	PoolScript activateCoin;
	PoolScript activateBird;
	PoolScript activateDragon;
	public AudioClip CoinBlip;
	public AudioClip smallExplosionSound;
	public int score;
	public GUIText LoseText;
	public GUIText DiamondsCount;
	PoolScript activatePowerUp1;
	PoolScript activatePowerUp2;
	PoolScript activatePowerUp3;
	PoolScript activateCloud;
	public GameObject smallExplosion;
	public GameObject LargeExplosion;
	public GameObject fire;
	public GameObject bonusEffect;
	public int InitialEnemySpeed;
	public int scoreIncreaseRatio;
	private int diamonds;
	public int coinSpeed;
	public bool invincible = false;
	public int bulletLevel = 0;
	public int DragonHealth;
	public float coinSleep;
	public bool raining = false;
	public Texture2D BackBtn;
	public Texture2D Diamond;
	public bool IsDragon = false;
	private int TimeInt = 0;
	public ScrollingScript backGroundScrollScript;
	public float oldBackGroundSpeed;
	public float newBgSpeed = 0f;
	
	void Start ()
	{
		
		backGroundScrollScript = GameObject.Find ("Sky Quad").GetComponent<ScrollingScript> ();
		
		gameEnded = false;
		healthBarLength = (Screen.width / 2);
		
		activateBullet = GameObject.Find ("BulletPool").GetComponent<PoolScript> ();
		activateCoin = GameObject.Find ("coinPool").GetComponent<PoolScript> ();
		activateBird = GameObject.Find ("BirdPool").GetComponent<PoolScript> ();
		activateDragon = GameObject.Find ("DragonPool").GetComponent<PoolScript> ();
		
		activatePowerUp1 = GameObject.Find ("PowerUpPool1").GetComponent<PoolScript> ();
		activatePowerUp2 = GameObject.Find ("PowerUpPool2").GetComponent<PoolScript> ();
		activatePowerUp3 = GameObject.Find ("PowerUpPool3").GetComponent<PoolScript> ();
		
		speedPowerScript = GameObject.Find ("PlayerPlane").GetComponent<speedPowerUp> ();
		healthPowerScript = GameObject.Find ("PlayerPlane").GetComponent<HealthPowerUp> ();
		bulletsPowerScript = GameObject.Find ("PlayerPlane").GetComponent<bulletsPowerUp> ();
		LightningScript = GameObject.Find ("PlayerPlane").GetComponent<struckByLightning> ();
		rainScript = GameObject.Find ("PlayerPlane").GetComponent<RainEffect> ();
		
		activateCloud = GameObject.Find ("CloudPool").GetComponent<PoolScript> ();
		
		StartCoroutine (CoinControl ());
		oldBackGroundSpeed = backGroundScrollScript.Speed;
		StartCoroutine (BirdControl ());
		StartCoroutine (PowerUpControl ());
		
		StartCoroutine (CloudControl ());
		
		diamonds = 0;
	}
	
	private int counter = 0;
	
	void FixedUpdate ()
	{
		if (gameEnded) {
			return;
		}
		counter++;
		if (counter >= 20) {
			score += (1 * scoreIncreaseRatio);
			counter = 0;
		}
	}
	
	public GUITexture jumpTexture;
	public GUITexture fireTexture;
	int count;
	Touch touch;
	
	void Update ()
	{
		DragonControl ();
		
		count = Input.touchCount;
		
		for (int i = 0; i < count; i++) {
			touch = Input.GetTouch (i);
			
			if (jumpTexture.HitTest (touch.position)) {
				if (touch.phase == TouchPhase.Began)
					move_plane (1);
			}
			
			if (fireTexture.HitTest (touch.position)) {
				if (touch.phase == TouchPhase.Began)
					shootBullet ();
			}
			
		}
	}
	
	public void move_plane (int moveVertical)
	{
		
		rigidbody2D.AddForce (speed * Vector2.up);
		
		float minYSpeed = 0;
		float maxYSpeed = 3;
		float y = Mathf.Clamp (rigidbody2D.velocity.y, minYSpeed, maxYSpeed);
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, y);
	}
	
	GameObject currentBullet = null;
	Vector3 tempVec3 = new Vector3 (0, 0, 0);
	Vector2 tempVec2 = new Vector3 (0, 0);
	
	public void shootBullet ()
	{
		
		currentBullet = null;
		if (bulletLevel == 0) {
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -90);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (1000, 0);
			currentBullet.rigidbody2D.AddForce (tempVec2);
		} else if (bulletLevel == 1) {
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -90);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (1000, 0);
			currentBullet.rigidbody2D.AddForce (tempVec2);
			
			currentBullet = null;
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -45);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (500, 500);
			currentBullet.rigidbody2D.AddForce (tempVec2);
			
			currentBullet = null;
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -144);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (500, -500);
			currentBullet.rigidbody2D.AddForce (tempVec2);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (gameEnded)
			return;
		//		if(currHealth<=30){
		//			GameObject expl3 = Instantiate (fire) as GameObject;
		//			expl3.transform.position = new Vector3 (transform.position.x,transform.position.y+1f,expl3.transform.position.z);	
		//			expl3.transform.parent=transform;
		//		}
		if ((other.gameObject.tag == "target") && !invincible) {
			if (raining) {
				LightningScript.startEffect ();
			}
			adjustCurrentHealth (-10);
			
			if (GlobalData.SFX == true)
				AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
			
			//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
			if (other.gameObject.tag == "target") {
				other.gameObject.SetActive (false);
				
			}
			
			if (currHealth == 0) {
				LoseText.text = "Game Over";
				//				expl = Instantiate (LargeExplosion, other.transform.position, other.transform.rotation) as GameObject;
				
				//				splitScript script = (splitScript)actualPlaneBody.GetComponent (typeof(splitScript));
				//				script.start ();
				//				this.collider2D.enabled = false;
				GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
				this.collider2D.enabled = false;
				Destroy (this.gameObject);				
				gameEnded = true;
			}
			
			GameObject expl2 = Instantiate (smallExplosion, transform.position, transform.rotation) as GameObject;
			
		}
		
		//		else if (other.gameObject.tag == "Tree") 
		//		{
		//
		//			GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
		//
		//		
		//			this.collider2D.enabled = false;
		//			Destroy(this.gameObject);
		//
		//			 currHealth = 0;
		//			LoseText.text = "Game Over";
		//			gameEnded = true;
		//
		//		}
		else if (other.gameObject.tag == "coin") {
			Instantiate (bonusEffect, transform.position, transform.rotation);
			other.gameObject.SetActive (false);
			if (GlobalData.SFX == true)
				AudioSource.PlayClipAtPoint (CoinBlip, transform.position);
			//			score+=10;
			//			SetScoreText ();
			diamonds++;
			//						setDiamondsText ();
		} else if ((other.gameObject.tag == "speedPowerUp")) {
			speedPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "healthPowerUp")) {
			healthPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "bulletPowerUp")) {
			bulletsPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "Cloud") && !invincible) {
			rainScript.startEffect ();
			//			other.gameObject.SetActive (false);
		}
		
		
		
	}
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "generalWall" && !invincible) {
			
			adjustCurrentHealth (-10);
			
			//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
			//			other.gameObject.SetActive(false);
			
			if (currHealth == 0) {
				//								LoseText.text = "Game Over";
				//				expl = Instantiate (LargeExplosion, other.transform.position, other.transform.rotation) as GameObject;
				
				//				splitScript script = (splitScript)actualPlaneBody.GetComponent (typeof(splitScript));
				//				script.start ();
				//				this.collider2D.enabled = false;
				GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
				
				
				this.collider2D.enabled = false;
				Destroy (this.gameObject);
				//				Destroy (rotor);
				
				gameEnded = true;
			}
			
			GameObject expl2 = Instantiate (smallExplosion, transform.position, transform.rotation) as GameObject;
			
		}
		
	}
	
	void OnGUI ()
	{
		if (currentStyle == null) {
			
			currentStyle = new GUIStyle (GUI.skin.box);
			currentStyle.normal.background = MakeTex (2, 2, new Color (0f, 1f, 0f, 0.5f));
		}
		GUI.Box (new Rect (10, 10, healthBarLength, 20), currHealth + "%", currentStyle);
		
		if (GUI.Button (new Rect (Screen.width - 60, 75, 50, 30), BackBtn)) {
			Application.LoadLevel ("Menu");
		}
		
		GUI.Label (new Rect (Screen.width - 120, 20, 100, 50), "Score: " + score.ToString (), LabelStyle);
		GUI.Label (new Rect (Screen.width - 200, 20, 50, 50), Diamond);
		GUI.Label (new Rect (Screen.width - 170, 20, 50, 50), diamonds.ToString (), LabelStyle);
		
	}
	
	public void adjustCurrentHealth (int addedValue)
	{
		currHealth += addedValue;
		if (currHealth < 0) {
			currHealth = 0;
			LoseText.text = "Game Over";
			gameEnded = true;
		}
		if (currHealth > maxHealth)
			currHealth = maxHealth;
		if (maxHealth < 1)
			maxHealth = 0;
		
		healthBarLength = (Screen.width / 2) * (currHealth / maxHealth);
	}
	
	private Texture2D MakeTex (int width, int height, Color col)
	{
		Color[] pix = new Color[width * height];
		for (int i = 0; i < pix.Length; ++i) {
			pix [i] = col;
		}
		Texture2D result = new Texture2D (width, height);
		result.SetPixels (pix);
		result.Apply ();
		return result;
	}
	
	IEnumerator CoinControl ()
	{
		coinSpeed = 350;
		coinSleep = 0.1f;
		while (true) {
			var RandomSleep = Random.Range (2, 3);
			yield return new WaitForSeconds (RandomSleep);
			
			var RandomShape = Random.Range (0, 3);
			var RandomCoinCount = Random.Range (3, 7);
			
			
			var RandomNumber = Random.Range (-4, 4);
			GameObject currentCoin;
			
			if (RandomShape > 0 && RandomShape <= 1) {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (2, 4);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							currentCoin.transform.position = new Vector2 (12, RandomNumber);
							currentCoin.rigidbody2D.AddForce (new Vector2 (-coinSpeed, 0));
							
						}
						
					}
					yield return new WaitForSeconds (coinSleep);
				}
			} else if (RandomShape > 1 && RandomShape <= 2) {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (1, 3);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							currentCoin.transform.position = new Vector2 (12, RandomNumber);
							currentCoin.rigidbody2D.AddForce (new Vector2 (-coinSpeed, 0));
							
						}
					}
					yield return new WaitForSeconds (coinSleep);
				}
			} else {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (-3, -1);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							currentCoin.transform.position = new Vector2 (12, RandomNumber);
							currentCoin.rigidbody2D.AddForce (new Vector2 (-coinSpeed, 0));
							
						}
					}
					yield return new WaitForSeconds (coinSleep);
				}
			}	
			
			
			
			
			//						currentCoin = (GameObject)activateCoin.ActivateObject ();
			//			
			//						if (currentCoin != null) 
			//						{
			//								currentCoin.transform.position = new Vector2 (9, RandomNumber);
			//								currentCoin.rigidbody2D.AddForce (new Vector2 (-coinSpeed, 0));
			//						}
			//						
		}					
	}
	
	IEnumerator BirdControl ()
	{
		
		while (true) {
			
			InitialEnemySpeed += 5;
			
			var RandomNumber = Random.Range (-2, 4);
			
			GameObject currentBird;
			//						Debug.Log ("E3mly enemy law sam7t");
			
			
			//					Debug.Log("el wa2t="+Time.time);
			//			Debug.Log("el wa2t DELWA2TY="+TimeInt);
			
			if ((TimeInt % 10 == 0) && (TimeInt > 0)) {
				//							Debug.Log ("el mod esht3'al");
				if(speedPowerScript.isRunning){speedPowerScript.endPowerup();};
				oldBackGroundSpeed = backGroundScrollScript.Speed;
				
				TimeInt = 0;
				IsDragon = true;
				
			}
			
			if (!IsDragon) {
				if (TimeInt == 0)
				
					backGroundScrollScript.Speed = oldBackGroundSpeed;
				
				TimeInt ++;
				
				currentBird = (GameObject)activateBird.ActivateObject ();
				
				if (currentBird != null) {
					
					currentBird.transform.position = new Vector2 (12, RandomNumber);
					currentBird.rigidbody2D.AddForce (new Vector2 (-InitialEnemySpeed, 0));
				}
				//								yield return new WaitForSeconds (1.0f);
				
				
				
			}
			yield return new WaitForSeconds (1.0f);
			
		}				
	}
	
	public int dragonSpeed = 250;
	
	//		IEnumerator DragonControl ()
	//		{
	//
	//				
	//				dragonSpeed = 250;
	//				while (true) {
	//						//			InitialEnemySpeed += 5;
	//			
	//						GameObject currentDragon;
	//						currentDragon = (GameObject)activateDragon.ActivateObject ();
	//						if (currentDragon != null) {
	//								currentDragon.transform.position = new Vector2 (12, -2.820957f);
	//								currentDragon.rigidbody2D.AddForce (new Vector2 (-dragonSpeed, 0));
	//						}
	//						yield return new WaitForSeconds (3.0f);
	//				}				
	//		}
	
	void DragonControl ()
	{
		
		dragonSpeed = 250;
		
		
		//			InitialEnemySpeed += 5;

		GameObject currentDragon;
		
		if (IsDragon) {

			backGroundScrollScript.Speed = newBgSpeed;
			currentDragon = (GameObject)activateDragon.ActivateObject ();
			if (currentDragon != null) {
				currentDragon.transform.position = new Vector2 (10, -2.820957f);
				//												currentDragon.rigidbody2D.AddForce (new Vector2 (-dragonSpeed, 0));
			}
			
			//										IsDragon = false;
		}
		//			yield return new WaitForSeconds (0.0f);
		
		
	}
	
	public int powerUpSpeed = 350;
	
	IEnumerator PowerUpControl ()
	{
		powerUpSpeed = 350;
		
		while (true) {
			
			if (!IsDragon) {
				
				var RandomNumber = Random.Range (-2, 4);
				
				GameObject currentPowerUp;
				
				var RandomPowerUp = Random.Range (0, 3);
				
				if (RandomPowerUp > 0 && RandomPowerUp <= 1)
					currentPowerUp = (GameObject)activatePowerUp1.ActivateObject ();
				else if (RandomPowerUp > 1 && RandomPowerUp <= 2)
					currentPowerUp = (GameObject)activatePowerUp2.ActivateObject ();
				else
					currentPowerUp = (GameObject)activatePowerUp3.ActivateObject ();
				
				if (currentPowerUp != null) {
					currentPowerUp.transform.position = new Vector2 (12, RandomNumber);
					currentPowerUp.rigidbody2D.AddForce (new Vector2 (-powerUpSpeed, 0));
				}
			}
			yield return new WaitForSeconds (3.0f);
		}		
	}
	
	IEnumerator CloudControl ()
	{
		while (true) {
			GameObject currentCloud;
			if (!IsDragon) {
				currentCloud = (GameObject)activateCloud.ActivateObject ();
				if (currentCloud != null) {
					currentCloud.transform.position = new Vector2 (10, 4.0f);
					currentCloud.rigidbody2D.AddForce (new Vector2 (-250, 0));
				}
			}
			yield return new WaitForSeconds (3.0f);
		}				
	}
	
	void OnTouchDown ()
	{
		Debug.Log ("hi bolly");
		//		gameObject.rigidbody2D.AddForce (new Vector2 (0.0f, 1 * speed));
		
	}
	
	void OnTouchUp ()
	{
		Debug.Log ("hi bolly");
	}
	
	void OnTouchStay ()
	{
		Debug.Log ("hi bolly");
		//		mat.color = newColor;
		//		//		otherCube.rigidbody.AddForce (new Vector3 (0.0f, 1 * speed, 0.0f));
	}
	
	void OnTouchExit ()
	{
		Debug.Log ("hi bolly");
		//		mat.color = deafultColor;
	}
	
	//		public void SetScoreText ()
	//		{
	//				ScoreText.text = "Score: " + score.ToString ();
	//		}
	
	//		public void setDiamondsText ()
	//		{
	//				DiamondsCount.text = "" + diamonds.ToString ();
	//		}
}
