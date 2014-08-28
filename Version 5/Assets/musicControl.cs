using UnityEngine;
using System.Collections;

public class musicControl : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

		if (GlobalData.SFX == true) {
						if (!audio.isPlaying)
								audio.Play ();
				} else {
			audio.Pause();
				}
	
	}
}
