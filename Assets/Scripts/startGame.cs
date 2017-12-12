using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	bool isPushed;

	// Update is called once per frame
	void Update () {
		isPushed = this.GetComponent<pushButton>().getPush();
		if (isPushed) {
			SceneManager.LoadScene("Jeu (VR)", LoadSceneMode.Single);
		}
	}
}
