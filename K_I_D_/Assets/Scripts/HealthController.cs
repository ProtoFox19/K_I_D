using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public Light light;

	// Die Lebenszeit, die die Spielerfigur verwendet
	public float health = 5;

	public float maxHealth = 5;

	public float startHealth = 5;

	// Anzahl der Leben
	public float healthPoints = 5;

	// Anzahl der Lifepoints
	public float lifePoints = 3;

	public float startLifePoints = 3;

	// Eigenschaften des Lichtes
	public float minLight = 0.5F;

	private bool isDead = false;
	private bool isDamageable = true;

	// RigidBody erzeugen
	private Rigidbody rb2d;

	// Verbindung zum Animator und PlayerController herstellen
	Animator anim;
	PlayerController playerController;

	// Use this for initialization
	void Start () {

		rb2d = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		playerController = GetComponent<PlayerController> ();

		light = GetComponent<Light> ();

		// Level Index muss angepasst werden, wenn es Menü oder Begruessungsszenen gibt
		if (Application.loadedLevel == 0) {

			health = startHealth;
			lifePoints = startLifePoints;

		} else {

			health = PlayerPrefs.GetFloat ("Health");
			lifePoints = PlayerPrefs.GetFloat ("lifePoints");
		}
	}
	
	// Update is called once per frame
	void Update () {

		health -= 0.001F;
		light.intensity = health;

		CheckDead ();
	}

	void fixedUpdate () {


	}

	void ApplyDamage(float damage) {

		if (!isDead) {

			if (isDamageable) {

				healthPoints -= damage;
				health -= damage;

				CheckDead ();

				if (health >= minLight) {

					Damaging ();
					isDamageable = false;
					// Erst 2 Sekunden nach Schadenserhalt, kann der Spieler wieder Schaden nehmen
					Invoke ("ResetisDamageable", 2);
				} 
			}
		}
	}

	void CheckDead() {

		if (health <= minLight) {

			isDead = true;
			Dying ();
		}
	}

	void ResetisDamageable() {

		isDamageable = true;
	}
		
	void Dying () {

		// Dying / Wake Up Animation
		playerController.enabled = false;

		lifePoints --;

		if (lifePoints >= 0) {

			// Nach 2 Sekunden wird das Level neu gestartet
			Invoke ("StartGame", 2);


		} else {

			// Nach 3 Sekunden wird das Spiel neu gestartet
			Invoke ("RestartLevel", 3);		}
	}

	void Damaging () {

		// Damage Animation per Trigger??

	}

	// Erhoeht Health des Spielers
	public void AddHealth (float extraHealth) {

		health += extraHealth;

		light.intensity = Mathf.Min (health, maxHealth);
	}

	void StartGame() {

		Application.LoadLevel (0);
	}

	void RestartLevel() {

		health = startHealth;
		isDead = false;
		// Animation auf idle zurücksetzen
		playerController.enabled = true;
	}

	void onDestroy () {

		PlayerPrefs.SetFloat ("Health", health);
		PlayerPrefs.SetFloat ("LifePoints", lifePoints);
	}
}
