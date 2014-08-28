using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Texture2D Btn1;
	public Texture2D Btn2;

	public GUIStyle bollastyle;

	void OnGUI () {
		// Make a background box
//		GUI.Box(new Rect(Screen.width/2 - 100 ,Screen.height/2 -75,200,200), "Bolla's Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 -25,200,50), Btn1)) 
		{
			Application.LoadLevel("_MainScene");
		}
//
//		if(GUILayout.Button(" ",bollastyle)) 
//		{
//			Application.LoadLevel("_MainScene");
//		}

		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 +40,200,50), Btn2)) {
			Application.LoadLevel("Options");
		}
	}
}
