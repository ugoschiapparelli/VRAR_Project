using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gocredits : MonoBehaviour {

	bool isPushed;

	void Update () {
		isPushed = this.GetComponent<pushButton>().getPush();
		if (isPushed) {
			SceneManager.LoadScene("Credits", LoadSceneMode.Single);
		}

	}
}
