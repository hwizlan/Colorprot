using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickWall : MonoBehaviour {

	public GameObject shar;
	public GameObject wall;
	string nameWall;
	string colorWall;
	string colorShar;

	private GameObject forUp;

	public AudioClip wallClick;
	public AudioClip wallSelfUp;
	public AudioClip rolling;

	public bool roll;


	void Update () {
	}

	void FixedUpdate () {

		Debug.DrawRay (shar.transform.position, Vector3.forward * 20f, Color.green);
		Debug.DrawRay (shar.transform.position, Vector3.forward * 1f, Color.red);
		RaycastHit up;
		if (Physics.Raycast (shar.transform.position, Vector3.forward, out up, 1f)) {
			colorWall = up.collider.GetComponent<Renderer> ().material.name;
			colorShar = shar.GetComponent<Renderer> ().material.name;
			if (colorWall == colorShar) {
				up.transform.Translate (Vector3.up * 7f);
				ScoreText.scoreValue += 1;

				if (PlayerPrefs.GetInt ("SoundOn") != 0) {
					GetComponent<AudioSource> ().clip = wallSelfUp;
					GetComponent<AudioSource> ().Play ();
				}
			}
		}
			
		if (forUp != null) {
			forUp.transform.Translate (Vector3.up * 8f * Time.fixedDeltaTime);
//			print (forUp.gameObject.name);
		}
	}

	void OnMouseDown () {
		
		if (PlayerPrefs.GetInt ("SoundOn") != 0) {
			GetComponent<AudioSource> ().clip = wallClick;
			GetComponent<AudioSource> ().Play ();
		}

		Debug.DrawRay (shar.transform.position, Vector3.forward * 20f, Color.green);
		RaycastHit hit;

		if (Physics.Raycast (shar.transform.position, Vector3.forward, out hit, 20f)) {
			colorWall = hit.collider.GetComponent<Renderer> ().material.name;
			colorShar = shar.GetComponent<Renderer> ().material.name;
			nameWall = wall.gameObject.name + "(Clone)";

			if (hit.collider.name == nameWall && colorWall != colorShar) {
				forUp = hit.collider.gameObject;
//				hit.transform.Translate (Vector3.up * 7f);
//				print (hit.collider.name);
				ScoreText.scoreValue += 1;
			} 
				else {

				shar.GetComponent<__GamerController2 > ().speed = new Vector3 (0f, 0f, 20f);
				if (PlayerPrefs.GetInt ("SoundOn") != 0) {
					GetComponent<AudioSource> ().clip = rolling;
					GetComponent<AudioSource> ().Play ();
				}
//				Hide ();

			}

		}
	}

//	void Hide () {
//		
//
//
//		shar.GetComponent<__GamerController2 > ().panel.gameObject.SetActive (false);
//		shar.GetComponent<__GamerController2 > ().best.gameObject.SetActive (true);
//		shar.GetComponent<__GamerController2 > ().gamecnt.gameObject.SetActive (true);
//		shar.GetComponent<__GamerController2 > ().menu.gameObject.SetActive (true);
//	}

	//	void WallUp () {
	//		if (wallUp!=null) {
	//			wallUp.transform.position = new Vector3(wallUp.transform.position.x, wallUp.transform.position.y+Time.deltaTime*5f, wallUp.transform.position.z );
	//			print (wallUp.name + "VOT ETO");
	//		}
	//}
}
