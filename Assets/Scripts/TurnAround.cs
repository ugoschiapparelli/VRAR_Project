using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour {
	public float speed = 10.0f;
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.up, speed * Time.deltaTime);
	}
}
