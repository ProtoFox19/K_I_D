using UnityEngine;
using System.Collections;

public class just9 : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		// RigidBody
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Player")) {

			rb.useGravity = true;
		}
	}
}
