using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour {

	// RigidBody erzeugen
	private Rigidbody rb;

	//Um die Joystick eingaben in das Script zu bekommen.
	public virtualJoystick moveJoystick;

	// may the force be with you
	private float pushForce = 50;

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Obstacle")) {

			// Negation der aktuellen Fortbewegung
			float x = - rb.velocity.x;
			float y = - rb.velocity.y;
		
			// Kraft für den Rückstoß, wenn ein Obstacle beruehrt wird
			rb.AddForce (x * pushForce , y * pushForce, 0);
		}
	}

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Abbremsen des Spielers, falls ein Obstacle getroffen wurde
		Vector3 currentVelocity = rb.velocity;
		Vector3 oppositeForce = -currentVelocity;
		rb.AddRelativeForce (oppositeForce.x, oppositeForce.y, 0);
	}
}
