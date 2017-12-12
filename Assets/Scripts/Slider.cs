using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

	Vector3 basedPos;
	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
		basedPos = this.transform.localPosition;
		endPos = new Vector3(this.transform.parent.position.x - (this.transform.parent.localScale.x / 2) + (this.transform.localScale.x) + 0.19f, this.transform.position.y, this.transform.position.z);
		startPos = new Vector3(this.transform.parent.position.x + (this.transform.parent.localScale.x / 2) - (this.transform.localScale.x), this.transform.position.y, this.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
		if(this.transform.position.x < this.transform.parent.position.x - (this.transform.parent.localScale.x / 2) + (this.transform.localScale.x) + 0.19f){
			Debug.Log ("Fin");
			this.transform.position = endPos;
		} 
		if (this.transform.position.x >= this.transform.parent.position.x + (this.transform.parent.localScale.x / 2) - (this.transform.localScale.x)) {
			Debug.Log ("Début");
			this.transform.position = startPos;
		}
	}

	void volume(){
		float volume = ((this.transform.position.x - startPos.x) / ( endPos.x - startPos.x ))*1.0f;
		PlayerPrefs.SetFloat ("volume", volume);
		PlayerPrefs.Save ();
	}
}
