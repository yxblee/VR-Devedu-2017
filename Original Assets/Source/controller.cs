using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	private bool walk;
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (walk) {
			transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
		}

		if (transform.position.y < -10f) {
			transform.position = spawnPosition;
		}

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0f));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("Plane")) {
				walk = false;
			} else {
				walk = true;
			}
		}
		
	}
}
