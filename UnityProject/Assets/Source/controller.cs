using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	private bool walk;
	private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		// walk = true;
		spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (walk) {
			transform.position = transform.position 
				+ (Camera.main.transform.forward 
					* 0.5f * Time.deltaTime);
		}

		if (transform.position.y < -10.0f) { 
			transform.position = spawnPoint;
		}

		Ray ray = Camera.main.ViewportPointToRay(
			new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.name.Contains("Plane")) {
				walk = false;
			} else {
				walk = true;
			}
		}
	}
}
