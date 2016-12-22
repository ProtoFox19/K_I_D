using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	public float rotationspeed = 100F;

	public Vector3 eulerAngleVelocity;

	// Use this for initialization
	void Start () {

		// RigidBody
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.Rotate (Vector3.forward * rotationspeed);


		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * rotationspeed);

		rb.MoveRotation (rb.rotation * deltaRotation);
	}
}
