using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollider : MonoBehaviour {

	public float spaceshipSpeed = 10;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//ULTRA BOOST MOTOR VULCAN BY ELON MUSK
		transform.Translate(transform.right * spaceshipSpeed * Time.deltaTime);
	}
}