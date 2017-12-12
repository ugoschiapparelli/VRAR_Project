using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidRotation : MonoBehaviour {

	public GameObject camera;

	void Update() {
		transform.position = camera.transform.position;
	}
}
