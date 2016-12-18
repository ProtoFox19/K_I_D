using UnityEngine;
using System.Collections;

public class ActivateGravity : MonoBehaviour {

	// Zugriff auf RigidBody
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		// Zugriff auf den RigidBody
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Player")) {

			rb.useGravity = true;
		}
	}
}
