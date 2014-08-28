using UnityEngine;
using System.Collections;

public class replaceWalls : MonoBehaviour {

	public GameObject UpperWall;
	public GameObject LowerWall;
	public GameObject RightWall;
	public GameObject LeftWall;


	// Use this for initialization
	void Start () {
	
		Vector3 cameraBounds = camera.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height + UpperWall.renderer.bounds.extents.y, 0));
		UpperWall.transform.position= new Vector3 (UpperWall.transform.position.x, cameraBounds.y+UpperWall.renderer.bounds.extents.y, UpperWall.transform.position.z);
		LowerWall.transform.position= new Vector3 (LowerWall.transform.position.x, -(cameraBounds.y+LowerWall.renderer.bounds.extents.y), LowerWall.transform.position.z);
		RightWall.transform.position= new Vector3 ( (cameraBounds.x+RightWall.renderer.bounds.extents.x+3), RightWall.transform.position.y, RightWall.transform.position.z);
		LeftWall.transform.position= new Vector3 ( -(cameraBounds.x+LeftWall.renderer.bounds.extents.x+3), LeftWall.transform.position.y, LeftWall.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
