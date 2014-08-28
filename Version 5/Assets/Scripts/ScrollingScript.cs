using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {
		
	public float Speed;

	// Update is called once per frame
	void Update () 
	{
		renderer.material.mainTextureOffset = new Vector2 ((Time.time * Speed) % 1, 0f);
	}
}
