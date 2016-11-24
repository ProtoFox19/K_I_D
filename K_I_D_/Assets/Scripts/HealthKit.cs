using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {

	HealthController healthController;

	public float healthPoints = 1;

	// Use this for initialization
	void Start () {
		healthController = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthController> ();
	}
	
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			
			healthController.AddHealth (healthPoints);
			Destroy(gameObject);
		}
	}
}
