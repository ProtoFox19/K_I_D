﻿using UnityEngine;
using System.Collections;

// Diese Klasse aktiviert die Gravitation der Zahlen auf Befehl der Klasse AnimTrigger
public class TriggerCounter : MonoBehaviour {

	private int counter = 1;

	private string numberPath = "/Numbers/";

	ArrayList numbersRB = new ArrayList();

	void Start() {

		// RigidBody der Zahlen von 1 bis 9 abspeichern;
		for (float numbers = 1; numbers <= 9; numbers ++) {

			// Pfad in der Spielehierarchie festlegen
			string name = numbers.ToString ();
			string path = numberPath + name;

			// Zuordnung des RigidBody der jeweiligen Zahl
			Rigidbody numberRB  = GameObject.Find (path).GetComponent<Rigidbody>();
			numberRB.useGravity = false;
			numbersRB.Add (numberRB);
		}
	}

	// Aktivierung der Gravitation der getriggerten Zahl
	public void counttrigger () {

		Rigidbody current = (Rigidbody) numbersRB [counter - 1];

		current.useGravity = true;

		counter ++; 
	}

	public int Getcount () {

		return counter;
	}
}