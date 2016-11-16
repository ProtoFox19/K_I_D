using UnityEngine;
using System.Collections;

// Hier ist die Spielerkontrolle programmiert
public class PlayerController : MonoBehaviour {

	//maximale Fortbewegungsgeschwindigkeit
	public float maxSpeed = 2;

	// Zugriff auf Animatorkontroller
	private Animator anim;

	// Zugriff auf RigidBody2D
	private Rigidbody2D rb2d;

	// Blickrichtungen
	private bool movesUp = false;
	private bool movesDown = false;
	private bool movesLeft = false;
	private bool movesRight = false;

	// Use this for initialization
	void Start () {

		// Zugriff auf Animator beim Start initialisieren
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	// Hier werden die Befehle abgerufen
	void Update () {

		InputCheck ();

	}



	// Wird in einem festen Intervall aufgerufen
	// Hier werden die Animationen an den Animator übergeben
	void FixedUpdate() {

		// Abfrage ob sich der Player nach links, rechts bewegt und den Wert abfangen und in hor speichern
		float hor = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed", Mathf.Abs (hor));

		// Abfrage ob sich der Player nach oben, unten bewegt und den Wert abfangen und in ver speichern
		float ver = Input.GetAxis ("Vertical");

		// Zuweisung an das RigidBody um den Player in die entsprechende Richtung zu bewegen
		rb2d.velocity = new Vector2 (hor * maxSpeed, ver * maxSpeed);

		Animate ();
			
	}

	// Hier werden die Eingaben abgefragt und die entsprechenden bools werden gesetzt
	public void InputCheck () {

		// Abfrage für Pfeil nach oben
		if (Input.GetKey (KeyCode.UpArrow)) {

			movesUp = true;

		} else {

			movesUp = false;
		}

		// Abfrage für Pfeil nach unten
		if (Input.GetKey (KeyCode.DownArrow)) {

			movesDown = true;

		} else {

			movesDown = false;
		}

		// Abfrage für Pfeil nach links
		if (Input.GetKey (KeyCode.LeftArrow)) {

			movesLeft = true;

		} else {

			movesLeft = false;
		}

		// Abfrage für Pfeil nach rechts
		if (Input.GetKey (KeyCode.RightArrow)) {

			movesRight = true;

		} else {

			movesRight = false;
		}
	}

	// Hier werden die Animationen abgespielt
	public void Animate () {

		// Animation nach oben
		if (movesUp) {

			anim.SetBool ("movesUp", movesUp);

		} else {

			anim.SetBool ("movesUp", false);
		}

		// Animation nach unten
		if (movesDown) {

			anim.SetBool ("movesDown", movesDown);

		} else {

			anim.SetBool ("movesDown", false);
		}

		// Animation nach links
		if (movesLeft) {

			anim.SetBool ("movesLeft", movesLeft);

		} else {

			anim.SetBool ("movesLeft", false);
		}

		// Animation nach rechts
		if (movesRight) {

			anim.SetBool ("movesRight", movesRight);

		} else {

			anim.SetBool ("movesRight", false);
		}
	}

}
