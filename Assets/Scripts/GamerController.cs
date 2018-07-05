using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerController : MonoBehaviour {

	public Vector3 speed = new Vector3(0, 0 , 3);
	public Vector3 direction = new Vector3(0, 0, 1);
	private Vector3 movement;

	public GameObject platL;
	public GameObject platP;
	float raznL;
	float raznP;


	void Update () {
			movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			speed.z * direction.z);

		raznL = Vector3.Distance(transform.position,platL.transform.position);
		if (raznL > 60f) {
			platL.transform.position = new Vector3 (0f, 0f, platP.transform.position.z + 60f);
		}

		raznP = Vector3.Distance(transform.position,platP.transform.position);
		if (raznP > 60f) {
			platP.transform.position = new Vector3 (0f, 0f, platL.transform.position.z + 60f);
		}
			

	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().velocity= movement;
	}

}
