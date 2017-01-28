using UnityEngine;
using System.Collections;

public class GravityStuff : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		// RigidBody
		rb = GetComponent<Rigidbody> ();

	}

	void OnTriggerEnter (Collider other) {


		if (other.CompareTag("Player")) {

			rb.useGravity = true;
		}
	}
}
