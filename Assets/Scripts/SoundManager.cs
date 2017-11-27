using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip buttonClick;
	public AudioClip correct;
	public AudioClip wrong;

	public AudioSource soundSource;

	public void PlayButtonClick() {
		soundSource.Stop ();
		soundSource.volume = 1.0f;
		soundSource.clip = buttonClick;
		soundSource.Play ();
	}

	public void PlayCorrect() {
		soundSource.Stop ();
		soundSource.volume = 1.0f;
		soundSource.clip = correct;
		soundSource.Play ();
	}

	public void PlayWrong() {
		soundSource.Stop ();
		soundSource.volume = 0.4f;
		soundSource.clip = wrong;
		soundSource.Play ();
	}

}
