using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	public GameObject text;

	public string welcome = "Benutze das Steuerkreuz zur Bewegung";

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player")) {

			GameObject.Find ("/Joystickcanvas/Text").GetComponent<TriggerController> ().count ();

			text.GetComponent<ObstacleMove> ().applyVerticalSpeed (10);
		}
	}

	public void count () {



	}
}
