using UnityEngine;
using System.Collections;

public class bulletCollisionScript : MonoBehaviour {


//	public GameObject plane;
	public PlaneControl testObject; 
	// Use this for initialization
	public GameObject hit;
	void Start () {
		testObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "target") 
		{
			other.gameObject.SetActive(false);
//			Destroy(other.gameObject);
			testObject.score+=10;
//			testObject.SetScoreText ();

			Instantiate(hit,transform.position,transform.rotation);
//			Destroy(this.gameObject);
			this.gameObject.SetActive(false);
			
		}

		if (other.gameObject.tag == "Dragon") 
		{
			other.gameObject.SetActive(false);
			//			Destroy(other.gameObject);
			testObject.score+=10;

			//			testObject.SetScoreText ();
			
			Instantiate(hit,transform.position,transform.rotation);
			//			Destroy(this.gameObject);
			this.gameObject.SetActive(false);
			testObject.IsDragon = false;


			
		}

		if (other.gameObject.tag == "rightWall") {
						this.gameObject.SetActive (false);

//			Destroy(this.gameObject);
			
		}
		if (other.gameObject.tag == "generalWall") {
			this.gameObject.SetActive (false);
			
			//			Destroy(this.gameObject);
			
		}
		
	}
}
