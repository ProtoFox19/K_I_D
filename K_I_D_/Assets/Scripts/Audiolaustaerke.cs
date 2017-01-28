using UnityEngine;
using System.Collections;

public class Audiolaustaerke : MonoBehaviour {

    public AudioSource musik;
	// Use this for initialization
	void Start () {
        float aktuellesVolumen = PlayerPrefs.GetFloat("MusicVolumen");
        musik.volume = aktuellesVolumen;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
