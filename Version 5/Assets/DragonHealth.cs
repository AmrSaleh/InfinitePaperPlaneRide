using UnityEngine;
using System.Collections;

public class DragonHealth : MonoBehaviour {

	public int health =50; 
	public int hitAmount = 3;
	// Use this for initialization
	void Start () {
	
	}

	public bool hitDragon (){

				health -= hitAmount;

				if (health <= 0) {
						this.gameObject.SetActive (false);
						return true;
				}


				return false;
		}
	// Update is called once per frame
	void Update () {
	
	}
}
