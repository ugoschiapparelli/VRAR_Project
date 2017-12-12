using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	bool isPushed;
	
	// Update is called once per frame
	void Update () {
		isPushed = this.GetComponent<pushButton>().getPush();
		if (isPushed) {
			Application.Quit ();
		}
	}
}
