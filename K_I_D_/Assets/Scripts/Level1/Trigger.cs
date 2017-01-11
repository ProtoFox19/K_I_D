using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public GameObject triggeController;

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player")) {

			GameObject.Find ("/Triggers").GetComponent<TriggerController> ().count ();
		}
	}
}
