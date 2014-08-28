using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	public GameObject bullet;
	public GameObject canon1;
	public GameObject canon2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) {
						GameObject mybullet = (GameObject)Instantiate (bullet, canon1.transform.position, bullet.transform.rotation);
			mybullet.rigidbody2D.AddForce(new Vector2(1000,0));
//			mybullet =(GameObject) Instantiate (bullet, canon2.transform.position, canon2.transform.rotation);
//			mybullet.rigidbody2D.AddForce(new Vector2(0,500));
		}
	}
}
