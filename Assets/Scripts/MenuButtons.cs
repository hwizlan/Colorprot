using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	public GameObject SoundOnB, SoundOffB;


	// Use this for initialization
	void Start () {

		if (gameObject.name == "Sound") {
			if (PlayerPrefs.GetInt ("SoundOn") !=0 ) {
				SoundOnB.gameObject.SetActive (true);
				SoundOffB.gameObject.SetActive (false);

			}
			else {
				SoundOnB.gameObject.SetActive (false);
				SoundOffB.gameObject.SetActive (true);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		switch (gameObject.name) {
		case "NoAds":
			SceneManager.LoadScene ("game");
			break;
		case "Sound":
			if (PlayerPrefs.GetInt ("SoundOn") !=0) {
				PlayerPrefs.SetInt ("SoundOn", 0);
				SoundOnB.gameObject.SetActive (false);
				SoundOffB.gameObject.SetActive (true);
			}
			else {
				PlayerPrefs.SetInt ("SoundOn", 1);
				SoundOnB.gameObject.SetActive (true);
				SoundOffB.gameObject.SetActive (false);
			}
			break;
		}
	}
}
