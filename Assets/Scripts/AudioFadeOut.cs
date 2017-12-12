using UnityEngine;
using System.Collections;

//Code by Boris1998

public static class AudioFade {

	public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {

		while(audioSource.volume > 0.0f) {
			audioSource.volume -= Time.deltaTime / FadeTime;

			yield return null;
		}
	}

	public static IEnumerator FadeIn (AudioSource audioSource, float FadeTime) {

		while(audioSource.volume < 1.0f) {
			audioSource.volume += Time.deltaTime / FadeTime;

			yield return null;
		}
	}
}