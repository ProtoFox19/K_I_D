using UnityEngine;
using System.Collections;

public class HealthKit : MonoBehaviour {

	HealthController healthController;

	public float healthPoints = 1;

	private float brightness = 3;

	private float intensitiy = 5;

	// Eigenschaften des Lichtes
	private float minLight = 1F;
	private float Lightfreq = 2.5F;
	private float duration = 2F;

	public Light light;


	// Use this for initialization
	void Start () {
		healthController = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealthController> ();
		light = GetComponent<Light>();
	}

	void Update () {

		flicker ();
	}

	// Hier ist das Flimmern des Lichtes animiert
	void flicker () {

		float phi = Time.time / duration * Lightfreq * Mathf.PI;
		intensitiy = brightness * (Mathf.Cos(phi) * 0.5F + 1F) + minLight;
		light.intensity = intensitiy;
	}
	
	void OnTriggerEnter (Collider other) {

		if (other.gameObject.CompareTag ("Player")) {
			
			healthController.AddHealth (healthPoints);
			Destroy(gameObject);
		}
	}
}
