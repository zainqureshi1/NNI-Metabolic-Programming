using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour {

	public GameObject[] screens;
	public GameObject buttonNext;
	public GameObject buttonExit;

	public GameObject screen3OnClick;
	public GameObject screen3Graph;

	public CanvasGroup screen4ButtonsCanvas;
	public Image[] screen4ButtonImages;
	public bool[] screen4ButtonStates;

	public CanvasGroup screen5ButtonsCanvas;
	public GameObject screen5OnClick;
	public GameObject screen5Graph;

	public Image thumbImage;

	public Sprite screen4ButtonNormalSprite;
	public Sprite screen4ButtonTrueSprite;
	public Sprite screen4ButtonFalseSprite;

	public Sprite thumbTrueSprite;
	public Sprite thumbFalseSprite;

	public bool destroyPreviousScreens;
	private int currentScreen = 0;

	private bool screen4ButtonsAnimate = false;
	private float screen4ButtonsAnimTime = 1.0f;
	private float screen4ButtonsDeltaTime;

	private bool screen5ButtonsAnimate = false;
	private float screen5ButtonsAnimTime = 1.0f;
	private float screen5ButtonsDeltaTime;

	void Start() {
		HideThumb ();
		currentScreen = 0;
		for (int i = 0; i < screens.Length; i++) {
			if (screens [i] != null) {
				screens [i].SetActive (i == currentScreen);
			}
		}
		Invoke ("ShowButtonNext", 1.5f);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Home)) {
			Exit ();
		}
		if (screen4ButtonsAnimate) {
			screen4ButtonsDeltaTime += Time.deltaTime;
			if (screen4ButtonsDeltaTime >= screen4ButtonsAnimTime) {
				screen4ButtonsCanvas.alpha = 1.0f;
				screen4ButtonsAnimate = false;
			} else {
				screen4ButtonsCanvas.alpha = screen4ButtonsDeltaTime / screen4ButtonsAnimTime;
			}
		}
		if (screen5ButtonsAnimate) {
			screen5ButtonsDeltaTime += Time.deltaTime;
			if (screen5ButtonsDeltaTime >= screen5ButtonsAnimTime) {
				screen5ButtonsCanvas.alpha = 1.0f;
				screen5ButtonsAnimate = false;
			} else {
				screen5ButtonsCanvas.alpha = screen5ButtonsDeltaTime / screen5ButtonsAnimTime;
			}
		}
	}

	public void NextClicked() {
		HideThumb ();
		HideButtonNext ();
		int screenIndex = currentScreen + 1;
		switch (screenIndex) {
		case 1:
			screen3OnClick.SetActive (false);
			screen3Graph.SetActive (false);
			break;
		case 2:
			for (int i = 0; i < screen4ButtonImages.Length; i++) {
				screen4ButtonImages [i].sprite = screen4ButtonNormalSprite;
			}
			screen4ButtonsDeltaTime = 0;
			screen4ButtonsAnimate = true;
			Invoke ("ShowButtonNext", 3.0f);
			break;
		case 3:
			screen5OnClick.SetActive (false);
			screen5Graph.SetActive (false);
			buttonExit.SetActive (false);
			screen5ButtonsDeltaTime = 0;
			screen5ButtonsAnimate = true;
			break;
		}
		for (int i = 0; i < screens.Length; i++) {
			if (screens [i] != null) {
				screens [i].SetActive (i == screenIndex);
			}
		}
		if (destroyPreviousScreens && currentScreen < screens.Length) {
			GameObject.Destroy (screens [currentScreen]);
			screens [currentScreen] = null;
			Resources.UnloadUnusedAssets ();
		}
		currentScreen = screenIndex;
	}

	public void ExitClicked() {
		Exit ();
	}

	public void Screen3ButtonClicked(bool correct) {
		screen3OnClick.SetActive (true);
		screen3Graph.SetActive (true);
		ShowThumb (correct);
		Invoke ("ShowButtonNext", 2.0f);
	}

	public void Screen4ButtonClicked(int index) {
		bool state = screen4ButtonStates [index];
		screen4ButtonImages [index].sprite = state ? screen4ButtonTrueSprite : screen4ButtonFalseSprite;
		ShowThumb (state);
	}

	public void Screen5ButtonClicked(bool correct) {
		screen5OnClick.SetActive (true);
		screen5Graph.SetActive (true);
		ShowThumb (correct);
		Invoke ("ShowButtonExit", 2.0f);
	}

	private void ShowThumb(bool correct) {
		HideThumb ();
		thumbImage.sprite = correct ? thumbTrueSprite : thumbFalseSprite;
		Invoke ("ShowThumb", 0.3f);
	}

	private void ShowThumb() {
		thumbImage.gameObject.SetActive (true);
	}

	private void HideThumb() {
		thumbImage.gameObject.SetActive (false);
	}

	private void HideButtonNext() {
		buttonNext.SetActive (false);
	}

	private void ShowButtonNext() {
		buttonNext.SetActive (true);
	}

	private void ShowButtonExit() {
		buttonExit.SetActive (true);
	}

	private void Exit() {
		Application.Quit ();
	}

}
