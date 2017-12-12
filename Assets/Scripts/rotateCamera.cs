using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (this.GetComponent<pushButton> ().getPush ()) {
			Camera.current.transform.Rotate (Time.deltaTime * Vector3.up * 90);
		}
	}

}
