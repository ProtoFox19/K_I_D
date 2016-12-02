using UnityEngine;
using System.Collections;

// Hier ist die Spielerkontrolle programmiert
public class PlayerController : MonoBehaviour {

	//maximale Fortbewegungsgeschwindigkeit
	private float speed = 5;
	
    // Zugriff auf Animatorkontroller
    private Animator anim;

	// Zugriff auf RigidBody
	private Rigidbody rb;

	// Blickrichtungen GERADE
	private bool movesUp = false;
	private bool movesDown = false;
	private bool movesLeft = false;
	private bool movesRight = false;

	// Blickrichtungen SCHRAEG
	private bool movesUpRight = false;
	private bool movesUpLeft = false;
	private bool movesDownRight = false;
	private bool movesDownLeft = false;

    //Um die Joystick eingaben in das Script zu bekommen.
    public virtualJoystick moveJoystick;

    // Use this for initialization
    void Start () {

		// Zugriff auf Animator beim Start initialisieren
		anim = GetComponent<Animator>();
		// Zugriff auf den RigidBody
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	// Hier werden die Befehle abgerufen
	void Update () {

		// Aufruf der Methode, welche die Nutzereingabe ueberwacht
		InputCheck ();
	}

	// Wird in einem festen Intervall aufgerufen
	// Hier werden die Animationen an den Animator übergeben
	void FixedUpdate() {
	  
		// Aufruf der Animation Methode
        Animate ();

		// Festlegung des Positionsvektors für die Fortbewegung mittels Positions / Transformkomponente
        Vector3 position = transform.position;

		// Steuerung für Tastatureingabe
        if (Input.GetKey(KeyCode.UpArrow)) position.y += 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) position.y -= 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) position.x -= 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) position.x += 2.5f * Time.deltaTime;

		// Festlegung der Bewegungsichtungen
		float directionX = moveJoystick.inputDirection.x * speed;
		float directionY = moveJoystick.inputDirection.y * speed;

		// Steuerung über Joystick
        if (moveJoystick.inputDirection != Vector3.zero)
        {
			// Option A: -- Fortbewegung mittels Position Komponente
            // position += moveJoystick.inputDirection * 0.2f;
					
			// Option B: -- Fortbewegung mittels RigidBody Komponente
        }
		// Hinzufuegen der Kraft zur Fortbewegung
		rb.AddForce (directionX, directionY, 0);

		// Wie stark der Joystick in eine Richtung ausschlaegt
		// Dies ist nötig damit die Animationen den richtigen Uebergang haben und nicht z.B. folgendes passiert:
		// moveLeft -> idle -> moveUpLeft, sondern:
		// moveLeft -> moveupLeft
		float directionStrengthX;
		float directionStrengthY;

		// Korrektur des Auschlags und der Velocity, sodass es keine Negativen geben kann...
		if (directionX < 0) {

			directionStrengthX = -rb.velocity.x;

		} else {

			if (rb.velocity.x < 0) {

				directionStrengthX = -rb.velocity.x;

			} else {
				
				directionStrengthX = rb.velocity.x;
			}
		}

		if (directionY < 0) {

			directionStrengthY = -rb.velocity.y;

		} else {

			if (rb.velocity.y < 0) {

				directionStrengthY = -rb.velocity.y;

			} else {

				directionStrengthY = rb.velocity.y;
			}
		}

		// Uebergabe des Ausschlags an den speed Parameter im Animator
		// Hiervon haengt der richtige Uebergang der Animationen zueinander ab
		anim.SetFloat("speed", directionStrengthX + directionStrengthY);

		// -- Fortbewegung mittels Position Komponente
        // transform.position = position;
    }

	// Hier werden die Eingaben abgefragt und die entsprechenden bools werden gesetzt
	public void InputCheck () {

        float x = moveJoystick.inputDirection.x;
        float y = moveJoystick.inputDirection.y;
        double angleBetween=361;

        if (moveJoystick.inputDirection != Vector3.zero) { 
            Vector2 v2 = new Vector2(x, y);
            angleBetween = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
            if (angleBetween < 0) angleBetween = 360 + angleBetween;
            //angleBetween = 360 - angleBetween;
        }

		// Abfrage für Pfeil nach oben
        if (Input.GetKey (KeyCode.UpArrow) || (angleBetween >= 67.5 && angleBetween < 112.5)) {     //(angleBetween >= 240 && angleBetween < 300)

            movesUp = true;

        } else {

			movesUp = false; 
        }
			
		// Abfrage für Pfeil nach unten
		if (Input.GetKey (KeyCode.DownArrow) || (angleBetween >= 247.5 && angleBetween < 292.5)) { //(angleBetween >= 60 && angleBetween < 120)
        
            movesDown = true;

        } else {

			movesDown = false;
		}

		// Abfrage für Pfeil nach links
		if (Input.GetKey (KeyCode.LeftArrow) || (angleBetween >= 157.5 && angleBetween < 202.5)) {    

			movesLeft = true;

        } else {

			movesLeft = false;
		}

		// Abfrage für Pfeil nach rechts
		if (Input.GetKey (KeyCode.RightArrow) || ((angleBetween >= 337.5 && angleBetween <= 360 ) || (angleBetween < 22.5 && angleBetween > 0))) {      //&& angleBetween!=361
        
            movesRight = true;


        } else {

			movesRight = false;
		}
			
        // Abfrage für Pfeil nach rechts oben
       	if ((Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.UpArrow))  || (angleBetween >= 22.5 && angleBetween < 67.5)) {

                movesUpRight = true;

        } else {

                movesUpRight = false;
        }

         // Abfrage für Pfeil nach rechts unten
        if ((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) || (angleBetween >= 292.5 && angleBetween < 337.5)) {

            movesDownRight = true;

        } else {

             movesDownRight = false;
        }

            // Abfrage für Pfeil nach links oben
        if ((Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.UpArrow)) || (angleBetween >= 112.5 && angleBetween < 157.5)) {

            movesUpLeft = true;

        } else {

            movesUpLeft = false;
        }

            // Abfrage für Pfeil nach links unten
        if ((Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.DownArrow)) || (angleBetween >= 202.5 && angleBetween < 247.5)) {

            movesDownLeft = true;

        } else {

            movesDownLeft = false;
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
			
		// Animation nach rechts oben
		if (movesUpRight) {
            anim.SetBool("movesUpRight", movesUpRight);
        } else {
            anim.SetBool("movesUpRight", false);
        }

		// Animation nach rechts unten
		if (movesDownRight) {
            anim.SetBool("movesDownRight", movesDownRight);
        } else {
            anim.SetBool("movesDownRight", false);
        }

		// Animation nach links unten
		if (movesDownLeft) {
            anim.SetBool("movesDownLeft", movesDownLeft);
        } else {
            anim.SetBool("movesDownLeft", false);
        }

		// Animation nach links oben
		if (movesUpLeft) {
            anim.SetBool("movesUpLeft", movesUpLeft);
        } else {
            anim.SetBool("movesUpLeft", false);
        }
	}
}
