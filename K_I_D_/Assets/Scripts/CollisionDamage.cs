using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {

	public float damage = 1;

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Player")) {

			other.SendMessage ("ApplyDamage", damage);
		}
	}

	void OnTriggerStay (Collider other) {

		if (other.CompareTag ("Player")) {

			other.SendMessage ("ApplyDamage", damage);
		}
	}
}
