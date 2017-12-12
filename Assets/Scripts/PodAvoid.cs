using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodAvoid : MonoBehaviour {

	public float distance = 20.0f;
	public float speed = 36.0f;
	private Transform cam;
	private float avoidLeft = 0.0f;
	private Vector3 rotatePoint;

	// Use this for initialization
	void Start () {
		//rotatePoint = cam.InverseTransformPoint(transform.position - distance * (-transform.right));
		rotatePoint = transform.position - distance * transform.right;
		avoidLeft = 181.0f;
	}

	// Update is called once per frame
	void Update () {
		if (avoidLeft < 180)
		{
			Debug.Log(transform.eulerAngles.z);
			//Rotate around point
			transform.RotateAround(rotatePoint, Vector3.forward, speed * Time.deltaTime);
			//Rotate around forward axis
			transform.Rotate(0, 0, speed * Time.deltaTime);
			//Decrease angle
			avoidLeft += (speed * Time.deltaTime);
		} else {
			rotatePoint = transform.position - distance * transform.right;
		}
	}

	public void startLeftAvoid()
	{
		avoidLeft = 0.0f;
	}

	void OnDrawGizmosSelected() {
    Gizmos.color = Color.yellow;
    Gizmos.DrawSphere(rotatePoint, 1);
  }
}
