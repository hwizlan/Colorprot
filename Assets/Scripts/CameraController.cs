using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject obj;
	private Vector3 offset;

	void Start () {
		offset = transform.position - obj.transform.position;
	}

	void LateUpdate () {
		transform.position = obj.transform.position + offset;
	}

}
