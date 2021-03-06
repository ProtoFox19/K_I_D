﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour {

	public Light light;

	// Die Lebenszeit, die die Spielerfigur verwendet
	public float health = 5;

	public float maxHealth = 5;

	public float startHealth = 5;


	// Eigenschaften des Lichtes
	public float minLight = 0.12F;

	private bool isDead = false;
	private bool isDamageable = true;

	// RigidBody erzeugen
	private Rigidbody rb2d;

	// Verbindung zum Animator und PlayerController herstellen
	Animator anim;
	PlayerController playerController;

	public AudioClip clip;

	// Use this for initialization
	void Start () {

		GetComponent<AudioSource> ().playOnAwake = false;

		GetComponent<AudioSource>().clip = clip;

		rb2d = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();



        light = GetComponent<Light>();

		health = startHealth;

        

	}
	
	// Update is called once per frame
	void Update () {

		health -= 0.05F * Time.deltaTime;
		light.intensity = health;

		CheckDead ();
	}

	void fixedUpdate () {

    }

	void ApplyDamage(float damage) {

		if (!isDead) {

			if (isDamageable) {

				health -= damage;

				if (anim.GetBool ("movesLeft") || anim.GetBool ("movesDownLeft") || anim.GetBool ("movesUpLeft")) {

					anim.SetTrigger ("hitLeft");

				}

				else if (anim.GetBool ("movesRight") || anim.GetBool ("movesDownRight") || anim.GetBool ("movesUpRight")) {


					anim.SetTrigger ("hitRight");

				}

				else if (anim.GetBool ("movesUp")) {


					anim.SetTrigger ("hitUp");

				}

				else if (anim.GetBool ("movesDown")) {


					anim.SetTrigger ("hitDown");

				}

				else {

					anim.SetTrigger ("hitRight");
				}

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
		anim.SetBool ("isDead", true);

		// Dying / Wake Up Animation
		playerController.enabled = false;

        // Nach 2 Sekunden wird das Level neu gestartet
        Invoke ("StartGame", 2);
	}

	void Damaging () {

		// Damage Animation per Trigger??

	}

	// Erhoeht Health des Spielers
	public void AddHealth (float extraHealth) {

        AudioSource.PlayClipAtPoint(clip, transform.position, PlayerPrefs.GetFloat("EffektVolumen"));
        //GetComponent<AudioSource> ().Play ();

        float tempHealth = health + extraHealth;
        if (tempHealth > maxHealth)
        {
            health = maxHealth;
        }else { 
		    health += extraHealth;
        }
		light.intensity = health;
	}

	void StartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);  //habs mit dem SceneManager gemacht, ist wohl das neuste was man benutzen soll ...
	}

}
