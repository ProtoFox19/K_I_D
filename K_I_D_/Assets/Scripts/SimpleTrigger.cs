using UnityEngine;
using System.Collections;

public class SimpleTrigger : MonoBehaviour {

	public GameObject obstacle;

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player")) {

			GameObject.Find ("/Triggers").GetComponent<TriggerCounter> ().counttrigger ();

			obstacle.GetComponent<ObstacleMove> ().applyVerticalSpeed (10);
		}
	}
}
