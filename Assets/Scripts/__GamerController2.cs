using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class __GamerController2 : MonoBehaviour {

	public Vector3 speed = new Vector3(0f, 0f , 10f);
	private Vector3 direction = new Vector3(0f, 0f, 1f);
	private Vector3 movement;
	public GameObject platL;
	public GameObject platP;
	float raznL;
	float raznP;
	public Material[] gamerColor = new Material[4];
	private GameObject[] wallsL = new GameObject[10];
	private GameObject[] wallsP = new GameObject[10];
	int i,j;
	int distanceWallZ;
	public GameObject[] arrayWalls = new GameObject[5];  

	public Text score;
	public Text best;
	public Text gamecnt;
	private float zSpeed;

	public GameObject menu;

	public GameObject panel;

	public AudioClip colorChange;
	public AudioClip bump;

	void Start () {

		HideFalse ();

		GetComponent<Renderer> ().material = gamerColor[(Random.Range(0,4))];

		wallsL[0] = Instantiate (arrayWalls[Random.Range (0, arrayWalls.Length)], new Vector3(0f, 2f, 20f), Quaternion.identity) as GameObject;
		for (i = 1; i < 10; i++) {
			distanceWallZ = Random.Range(13, 15);
			if (wallsL[i - 1].transform.position.z < 65f) 
			{
				Vector3 spawnPos = new Vector3 (0f, 2f, wallsL[i - 1].transform.position.z + distanceWallZ);
				wallsL[i] = Instantiate (arrayWalls[Random.Range (0, arrayWalls.Length)], spawnPos, Quaternion.identity) as GameObject; 
			}
				else break;
		}
	}

	void Update () {
		zSpeed += 0.0009f;
		movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			(speed.z+zSpeed) * direction.z);

		raznL = Vector3.Distance(transform.position,platL.transform.position);
		if (raznL > 60f) 
		{
			platL.transform.position = new Vector3 (0f, 0f, platP.transform.position.z + 60f);
			platL.GetComponent<Renderer> ().material.color = new Color (platP.GetComponent<Renderer> ().material.color.r+0.03f,platP.GetComponent<Renderer> ().material.color.g, platP.GetComponent<Renderer> ().material.color.b);
			for (i = 0; i < 10; i++) 
			{
				Destroy(wallsL[i]);
			}

			wallsL[0] = Instantiate (arrayWalls[Random.Range (0, arrayWalls.Length)], new Vector3(0f, 2f, platP.transform.position.z+35f), Quaternion.identity) as GameObject;	
			for (i = 1; i < 10; i++)
			{
				distanceWallZ = Random.Range(10, 13);
				if (wallsL[i - 1].transform.position.z < platP.transform.position.z+75f)
				{
					Vector3 spawnPos = new Vector3 (0f, 2f, wallsL[i - 1].transform.position.z + distanceWallZ);
					wallsL[i] = Instantiate (arrayWalls[Random.Range (0, arrayWalls.Length)], spawnPos, Quaternion.identity) as GameObject; 
				}
				else
					break;
			}		

		}


		raznP = Vector3.Distance (transform.position, platP.transform.position);
		if (raznP > 60f) 
		{
			platP.transform.position = new Vector3 (0f, 0f, platL.transform.position.z + 60f);
			platP.GetComponent<Renderer> ().material.color = new Color (platL.GetComponent<Renderer> ().material.color.r+0.03f ,platL.GetComponent<Renderer> ().material.color.g,platL.GetComponent<Renderer> ().material.color.b);
			for (j = 0; j < 10; j++) 
			{
				Destroy (wallsP [j]);
			}

			wallsP [0] = Instantiate (arrayWalls [Random.Range (0, arrayWalls.Length)], new Vector3 (0f, 2f, platL.transform.position.z + 35f), Quaternion.identity) as GameObject;	
			for (j = 1; j < 10; j++) 
			{
				distanceWallZ = Random.Range (10, 13);
				if (wallsP [j - 1].transform.position.z < platL.transform.position.z + 75f) 
				{
					Vector3 spawnPos = new Vector3 (0f, 2f, wallsP [j - 1].transform.position.z + distanceWallZ);
					wallsP [j] = Instantiate (arrayWalls [Random.Range (0, arrayWalls.Length)], spawnPos, Quaternion.identity) as GameObject; 
				} 
				else
					break;
			}
		}
	

		if (Input.GetKey("escape")) {
			Application.Quit ();
			print ("Quit");
		}
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().velocity= movement;
	}

	void OnTriggerEnter (Collider soundChange)
	{
		if (PlayerPrefs.GetInt ("SoundOn") != 0) {
			GetComponent<AudioSource> ().clip = colorChange;
			GetComponent<AudioSource> ().Play ();
		}

	}

	void OnTriggerExit (Collider colorChange)
	{
		int c = Random.Range (0, 4);
		GetComponent<Renderer> ().material = gamerColor [c];
		ScoreText.scoreValue += 1;

	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "Wall0(Clone)") {
			HideTrue ();
		}
		if (other.gameObject.name == "Wall1(Clone)") {
			HideTrue ();
		}
		if (other.gameObject.name == "Wall2(Clone)") {
			HideTrue ();
		}
		if (other.gameObject.name == "Wall3(Clone)") {
			HideTrue ();
		}
	
	}

	void HideTrue () {
		
		if (PlayerPrefs.GetInt ("SoundOn") != 0) {
			GetComponent<AudioSource> ().clip = bump;
			GetComponent<AudioSource> ().Play ();
		}

		panel.gameObject.SetActive (false);
		best.gameObject.SetActive (true);
		gamecnt.gameObject.SetActive (true);
		menu.gameObject.SetActive (true);
	}

	void HideFalse () {
		panel.gameObject.SetActive (true);

		best.gameObject.SetActive (false);
		gamecnt.gameObject.SetActive (false);
		menu.gameObject.SetActive (false);
	}

}
