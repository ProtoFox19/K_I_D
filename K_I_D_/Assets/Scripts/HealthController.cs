using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public Light light;

	// Die Lebenszeit, die die Spielerfigur verwendet
	public float health = 5;

	public float maxHealth = 5;

	private float startHealth;

	// Anzahl der Leben
	public float healthPoints = 5;

	// Anzahl der Lifepoints
	public float lifePoints = 3;

	public float startLifePoints = 3;

	// Eigenschaften des Lichtes
	public float minLight = 0.5F;
	public float Lightfreq = 1;
	public float duration = 0.1F;

	private bool isDead = false;
	private bool isDamageable = true;

	// may the force be with you
	private float pushForce = 100;

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

		// Abbremsen des Spielers, falls ein Obstacle getroffen wurde
		Vector3 currentVelocity = rb2d.velocity;
		Vector3 oppositeForce = -currentVelocity;
		rb2d.AddRelativeForce (oppositeForce.x, oppositeForce.y, 0);

		flicker ();
	}

	// Hier ist das Flimmern des Lichtes animiert
	void flicker () {

		float phi = Time.time / duration * Lightfreq * Mathf.PI;
		health = healthPoints * (Mathf.Cos(phi) * 0.5F + 0.5F) + minLight;
		light.intensity = health;
	}

	void ApplyDamage(float damage) {

		if (!isDead) {

			if (isDamageable) {

					healthPoints -= damage;

					if (health <= minLight) {

						isDead = true;
						Dying ();

					} else {

						Damaging ();
						isDamageable = false;
						// Erst 2 Sekunden nach Schadenserhalt, kann der Spieler wieder Schaden nehmen
						Invoke ("ResetisDamageable", 2);
					} 
			}
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

		// PushBack Animation 
		float x = transform.position.x;
		float y = transform.position.y;

		rb2d.AddRelativeForce (-x * pushForce , -y * pushForce, 0);
	}

	// Erhoeht Health des Spielers
	public void AddHealth (float extraHealth) {

		health += extraHealth;

		health = Mathf.Min (health, maxHealth);

		light.intensity = health;
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
