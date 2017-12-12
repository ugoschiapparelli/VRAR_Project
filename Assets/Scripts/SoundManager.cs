using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource idle;
	public AudioSource run;
	public AudioSource wind;
	public AudioSource bip;
	public AudioSource axel;

	bool runPlaying = false;
	bool idlePlaying = false;
	bool windPlaying = false;
	bool bipPlaying = false;
	bool axelPlaying = false;

	SpaceControl sc;

	void Start() {
		sc = this.GetComponent<SpaceControl> ();
		bip.volume = 0.3f;
		bip.Play ();
		wind.volume = 0.3f;
		wind.Play ();

		idle.volume = 0.0f;
		idle.Play ();
		axel.volume = 0.0f;
		axel.Play ();
		run.volume = 0.0f;
		run.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//Set general volume
		float volume = PlayerPrefs.GetFloat ("volume", 0.5f);
		AudioListener.volume = volume;

		float speed = sc.CurrentSpeed ();

		int cs = sc.CurrentState ();

		switch (cs) {
		case 0: //Si rien : idle
			StartCoroutine (AudioFade.FadeIn (idle, 1.0f));
			StartCoroutine (AudioFade.FadeOut (run, 1.0f));
			StartCoroutine (AudioFade.FadeOut (axel, 1.0f));
			wind.volume = 0.3f;
			break;

		case 1: //Si accel : axel + wind plus en plus fort
			StartCoroutine (AudioFade.FadeOut (idle, 1.0f));
			StartCoroutine (AudioFade.FadeOut (run, 1.0f));
			StartCoroutine (AudioFade.FadeIn (axel, 1.0f));
			wind.volume = 0.6f;
			break;

		case 2: //Si run : run + wind fort
			float pitch = 1.0f + (speed / 200.0f);
			StartCoroutine (AudioFade.FadeOut (idle, 1.0f));
			StartCoroutine (AudioFade.FadeIn (run, 1.0f));
			StartCoroutine (AudioFade.FadeOut (axel, 1.0f));
			run.pitch = pitch;
			wind.volume = 0.6f;
			break;

		default:
			run.Stop ();
			runPlaying = false;
			axel.Stop ();
			axelPlaying = false;
			idle.Stop ();
			idlePlaying = false;
			wind.volume = 0.3f;
			break;
		}





	}
}
