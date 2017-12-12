using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class SpaceControl : MonoBehaviour {

	public float acceleration = 10;
	public float minSpeed = 0;
	public float maxSpeed = 400;

	Controller controller;
	PodAvoid podAvoid;
	float initialpos;
	float spaceshipSpeed = 10;
	bool fistClose = false;
	bool vrille = false;
	int tmp =0;
	int currentState = 0;



	// Use this for initialization
	void Start () {
		controller = new Controller();
		podAvoid = (PodAvoid)this.GetComponent (typeof(PodAvoid));
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (spaceshipSpeed);
		Frame frame = controller.Frame();
		if (frame.Hands.Count == 2) {
			Hand leftHand;
			Hand rightHand;
			if (frame.Hands [0].IsLeft) {
				leftHand = frame.Hands [0];
				rightHand = frame.Hands [1];
			} else {
				rightHand = frame.Hands [0];
				leftHand = frame.Hands [1];
			}

			if (rightHand.GrabStrength == 1 && leftHand.GrabStrength == 1) {
				if (!fistClose) {
					//changement de vitesse
					initialpos = rightHand.PalmPosition [2];
					fistClose = true;
				} else {
					spaceshipSpeed += (initialpos - rightHand.PalmPosition [2])/acceleration;
					spaceshipSpeed = Mathf.Min (maxSpeed, Mathf.Max (minSpeed, spaceshipSpeed));
				}
				currentState = 1;
			} else {
				if (fistClose) {
					fistClose = false;
				}
				//Debug.Log ("left");
				//				Debug.Log (leftHand.PalmPosition);
				//Debug.Log (leftHand.PalmVelocity);
				//Debug.Log ("right");
				//				Debug.Log (rightHand.PalmPosition);
				//Debug.Log (rightHand.PalmVelocity);

				// Lateral Move = Roulis
				float lateralMove = leftHand.PalmPosition [1] - rightHand.PalmPosition [1];
				transform.Rotate (Vector3.back * lateralMove * Time.deltaTime);

				// Vertical Move = Tangage
				float verticalMove = (leftHand.Direction [1] + rightHand.Direction [1]) / 2;
				Vector3 verticalDir = Quaternion.AngleAxis (90 * verticalMove, Vector3.left) * Vector3.forward;
				transform.Rotate (Vector3.left * 100 * verticalMove * Time.deltaTime);

				//Lacet
				float rotateMove = rightHand.PalmPosition [2] - leftHand.PalmPosition [2];
				transform.Rotate (Vector3.up * rotateMove * Time.deltaTime);



				if (leftHand.PalmVelocity [0] > 500 && leftHand.PalmPosition [0] < 0) {
					if (tmp > (60 * 5)) {
						podAvoid.startLeftAvoid ();
						tmp = 0;
					}
				} else if (rightHand.PalmVelocity [0] > 500 && rightHand.PalmPosition [0] > 0) {
					if (tmp > (60 * 5)) {
						podAvoid.startLeftAvoid ();
						tmp = 0;
					}
				}

				//State
				currentState = 0;
				if (spaceshipSpeed > 20.0f)
					currentState = 2;

			}

			//ULTRA BOOST MOTOR VULCAN BY ELON MUSK
			transform.Translate (Vector3.forward * spaceshipSpeed * Time.deltaTime);
			tmp++;
			//Debug.Log (tmp);
		}
	}

	public int CurrentState() {
		return currentState;
	}

	public float CurrentSpeed() {
		return spaceshipSpeed;
	}
}