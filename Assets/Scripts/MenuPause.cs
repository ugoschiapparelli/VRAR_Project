using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

	public GameObject startline;
	public GameObject pauseUi;
	Controller controller;

	private Frame frame;
	private Khronos khronos;
	private bool isShowing;
	private float quitTimer = 0.0f;

	// Use this for initialization
	void Start () {
		controller = new Controller();
		khronos = startline.GetComponent<Khronos> ();
		isShowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		frame = controller.Frame();
		//If no hands 
		if (frame.Hands.Count < 2) {
			//Pause
			khronos.Pause ();
			//Draw canvas
			isShowing = true;
			if (frame.Hands.Count == 1) {
				//Pinch detection
				Hand hand = frame.Hands[0];
				Debug.Log (hand.PinchStrength);
				if (hand.PinchStrength > 0.75f) {
					quitTimer += Time.deltaTime;
				} else {
					quitTimer = 0.0f;
				}

			}
		} else {
			khronos.Unpause ();
			isShowing = false;
		}
		pauseUi.SetActive (isShowing);

		if (quitTimer > 2.0f)
			SceneManager.LoadScene ("Interface",LoadSceneMode.Single);
	}
}
