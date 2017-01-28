using UnityEngine;
using System.Collections;

// Die Klasse triggert die einzelnen Animationen der Zahlen im Spiel
public class AnimTrigger : MonoBehaviour {

	private string name;


	void Start () {

		name = transform.name;
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Player")) {

			GameObject.Find ("/Triggers").GetComponent<TriggerCounter> ().counttrigger ();

			// Ist es ein unsichtbarer Trigger im Spiel, so zerstoere diesen
			if (gameObject.CompareTag ("Animtrigger")) {

				Destroy (gameObject);
			}

			// Trigger entfernen, falls es sich um eine Zahl handelt
			if (gameObject.CompareTag ("Number")) {

				Destroy (gameObject.GetComponent<AnimTrigger>());
			}
		}
	}
}
