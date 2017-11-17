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
		soundSource.clip = buttonClick;
		soundSource.Play ();
	}

	public void PlayCorrect() {
		soundSource.Stop ();
		soundSource.clip = correct;
		soundSource.Play ();
	}

	public void PlayWrong() {
		soundSource.Stop ();
		soundSource.clip = wrong;
		soundSource.Play ();
	}

}
