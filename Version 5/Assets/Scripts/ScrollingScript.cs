using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {
	
	
	public float Speed;
	float old;
	
	// Update is called once per frame
	void Update () 
	{
		//		Debug.Log ("time=" +Time.time);
		Debug.Log ("delta=" + Time.deltaTime);
		old += Time.deltaTime * Speed;
		//		renderer.material.mainTextureOffset = new Vector2 ((Time.time * Speed) % 1, 0f);
		renderer.material.mainTextureOffset = new Vector2(old, 0f);
	}
}



