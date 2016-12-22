using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	// Richtungsvektor
	private Vector3 push = new Vector3 (0, 0, 0);

	// Geschwindigkeit
	public float speed;
	public float rotationspeed = 100F;

	// Zur Steuerung der Bouncer Collider
	private bool up = false;
	private bool down = false;

	public bool vertikal = false;
	public bool horizontal = false;
	public bool rotate = false;

	// Noetig fier Rotation mittels Quaternion
	// public Vector3 eulerAngleVelocity;

	// Use this for initialization
	void Start () {

		// RigidBody
		rb = GetComponent<Rigidbody> ();

		// Verbindung zum Mesh Renderer
		MeshRenderer mesh = GetComponent<MeshRenderer> ();

		// Beim Starten nur Schatten zeigen
		mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

		if (vertikal == true) {

			push.y = speed;

			horizontal = false;
		}

		if (horizontal == true) {

			push.x = speed;

			vertikal = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Update is called once per frame
	void FixedUpdate () {

		// Bewegen
		rb.AddForce (push);

		// Abbremsen
		Vector3 currentVelocity = rb.velocity;
		Vector3 oppositeForce = -currentVelocity;
		rb.AddForce (oppositeForce.x, oppositeForce.y, 0);

		// Rotation
		if (rotate == true) {

			transform.Rotate (Vector3.forward * rotationspeed);

			// Rotation mittels Quaternion
			//Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * rotationspeed);
			//rb.MoveRotation (rb.rotation * deltaRotation);

			// Rotation mittels Torque
			//rb.AddTorque (0, 0, 10);
		}
	}

	// Beim Kollidieren mit den eigenen Bouncer Collidern Richtungswechsel vornehmen
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("BouncerUp") && up == false) {

			push *= -1;

			up = true;

			down = false;
		}

		if (other.CompareTag("BouncerDown") && down == false) {

			push *= -1;

			down = true;

			up = false;
		}
	}

	public void applyVerticalSpeed (float speedOther) {

		push.x = speedOther;
	}
}
