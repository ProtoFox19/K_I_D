using UnityEngine;
using System.Collections;

// Hier ist die Spielerkontrolle programmiert
public class PlayerController : MonoBehaviour {

	//maximale Fortbewegungsgeschwindigkeit
	public float maxSpeed = 2;

    // Zugriff auf Animatorkontroller
    private Animator anim;

	// Zugriff auf RigidBody2D
	//private Rigidbody2D rb2d;

	// Blickrichtungen
	private bool movesUp = false;
	private bool movesDown = false;
	private bool movesLeft = false;
	private bool movesRight = false;

    //Um die Joystick eingaben in das Script zu bekommen.
    public virtualJoystick moveJoystick;

    // Use this for initialization
    void Start () {

		// Zugriff auf Animator beim Start initialisieren
		anim = GetComponent<Animator>();
	//	rb2d = GetComponent<Rigidbody2D>();
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

		/* Zuweisung an das RigidBody um den Player in die entsprechende Richtung zu bewegen
        Hab ich erstmal rausgenommen da er den Joystick keinen rickbody übergeben kann ... deswegen nicht wundern, an sich brauchen wir auch kein Rickbody soweit ich
        das bis jetzt beurteilen kann, da wir eh keine Schwerkraft auf unserem Caracter setzen ... aber zunot geht das alles wieder schnell rückgängig zu machen*/
		//rb2d.velocity = new Vector3 (hor * maxSpeed, ver * maxSpeed);
        
        Animate ();



        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) position.y += 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) position.y -= 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) position.x -= 2.5f * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) position.x += 2.5f * Time.deltaTime;

        if (moveJoystick.inputDirection != Vector3.zero)
        {
            position += moveJoystick.inputDirection * 0.2f;

        }

        transform.position = position;

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
        angleBetween = 360 - angleBetween;

        }
        

        // Abfrage für Pfeil nach oben
        if (Input.GetKey (KeyCode.UpArrow) || (angleBetween >= 240 && angleBetween < 300)) {

			movesUp = true;

		} else {

			movesUp = false; 

        }



		// Abfrage für Pfeil nach unten
		if (Input.GetKey (KeyCode.DownArrow) || (angleBetween >= 60 && angleBetween < 120)) { //(y < -0.5 && x < 0.5 && x > -0.5)

			movesDown = true;

        } else {

			movesDown = false;
		}

		// Abfrage für Pfeil nach links
		if (Input.GetKey (KeyCode.LeftArrow) || (angleBetween >= 150 && angleBetween < 210)) {    //(x < -0.5 && y < 0.5 && y > -0.5)

			movesLeft = true;

        } else {

			movesLeft = false;
		}

		// Abfrage für Pfeil nach rechts
		if (Input.GetKey (KeyCode.RightArrow) || (angleBetween >= 330 && angleBetween!=361 || angleBetween < 30)) {
           
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
