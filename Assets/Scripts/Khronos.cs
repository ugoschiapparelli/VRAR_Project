using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Khronos : MonoBehaviour {
	public float delayValue = 2.0f;
	public GameObject timerUI;
	public GameObject besttimeUI;

	public GameObject spaceship;
	public GameObject speedUI;

	TextMeshProUGUI speedText;

	TextMeshProUGUI timerText;

	TextMeshProUGUI bestText;

	private float timer = 0.0f;
	private bool startTimer = false;
	private float delay;
	private bool startDelay = false;
	private bool arrived = false;
	private bool pause = true;
	// Use this for initialization
	void Start () {
		delay = delayValue;
		timerText = timerUI.GetComponent<TextMeshProUGUI>();
		bestText = besttimeUI.GetComponent<TextMeshProUGUI>();
		speedText = speedUI.GetComponent<TextMeshProUGUI>();
		bestText.SetText ("RECORD : " + this.LoadBestTime().ToString ());

		timerText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(255,227,0,255));
		timerText.fontSharedMaterial.SetColor (ShaderUtilities.ID_GlowColor, new Color32(255,227,0,255));
		timerText.UpdateMeshPadding ();

		speedText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(0,255,0,255));
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer && !pause)
			timer += Time.deltaTime;

		if (startDelay) {
			if (delay > 0.0f) {
				delay -= Time.deltaTime;
			} else {
				delay = delayValue;
				startDelay = false;
			}
		}
		if (!arrived)
			timerText.SetText (timer.ToString ());
		else {
			timerText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(255,0,0,255));
			timerText.fontSharedMaterial.SetColor (ShaderUtilities.ID_GlowColor, new Color32(255,0,0,255));
			timerText.UpdateMeshPadding ();
		}

		//Speed
		SpaceControl sc = spaceship.GetComponent<SpaceControl> ();
		int speed = Mathf.RoundToInt(sc.CurrentSpeed ());
		speedText.SetText (speed.ToString ());
		if (speed > 300)
			speedText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(255,0,0,255));
		else if (speed > 150)
			speedText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(255,255,0,255));
		else
			speedText.fontSharedMaterial.SetColor ("_GlowColor", new Color32(0,255,0,255));
	}

	public void Pause() {
		pause = true;
	}

	public void Unpause() {
		pause = false;
	}

	public float LoadBestTime() {
		return PlayerPrefs.GetFloat ("bestTime", 9999.999f);
	}

	void SaveBestTime(float time) {
		if (time < this.LoadBestTime ()) {
			PlayerPrefs.SetFloat ("bestTime", time);
			PlayerPrefs.Save ();
			bestText.SetText ("RECORD : " + time.ToString ());
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!startDelay) {
			if (startTimer) {
				Debug.Log (timer);
				SaveBestTime (timer);
				arrived = true;
			} else {
				startTimer = true;
			}
			startTimer = true;
			startDelay = true;
		}
	}
}
