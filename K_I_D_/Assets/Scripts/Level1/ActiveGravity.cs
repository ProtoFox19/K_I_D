using UnityEngine;
using System.Collections;

public class ActiveGravity : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		// RigidBody
		rb = GetComponent<Rigidbody> ();
	
	}

	void OnTriggerEnter (Collider other) {


		if (other.CompareTag("Number")) {

			rb.useGravity = true;
		}
	}
}
