using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushButton : MonoBehaviour {

	Vector3 basedPos;
	float timeLeft = 2;
	bool push = false;
	bool first = false;
	bool second = false;

	// Use this for initialization
	void Start () {
		basedPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.tag == "front") {
			if (this.transform.position.z < this.basedPos.z) {
				this.transform.position = this.basedPos;
			} 
			if (this.transform.position.z >= this.transform.parent.position.z && !push) {
				this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				push = true;
			}
		} else {
			if(this.transform.position.z > this.basedPos.z) {
				this.transform.position = this.basedPos;
			} 
			if (this.transform.position.z <= this.transform.parent.position.z && !push) {
				this.GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);
				push = true;
			}
		}
		if(push) {
			timeLeft -= Time.deltaTime;
			if(timeLeft < 0){
				this.transform.position = this.basedPos;
				push = false;
				timeLeft = 2;
			}
		}
	}

	public bool getPush(){
		return push;
	}
}
