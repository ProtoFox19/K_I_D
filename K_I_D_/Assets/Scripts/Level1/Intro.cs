using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public string welcome = "Benutze das Steuerkreuz zur Bewegung ... ";

	public string move = "... Nehme dir ein wenig Zeit, dich umzuschauen";

	public string where = "Du befindest dich gerade in einem Traum";

	public string live = "Deine Spielerfigur verliert mit der Zeit an Licht ... ";

	public string live2 = "... dieses Licht stellt dein Leben dar";

	public string live3 = "... lasse es nicht erlischen!\nSammle dazu die schwebenden Lichter ein";

	public string shadows = "Pass gut auf die Schatten auf!\n Sie entziehen dir Licht !";

	public string tip = "Siehe dich immer gut um und nutze deine Umgebung";

	public string collapse = "Was ist das? Was passiert?\n Es bricht alles zusammen ?!?!";

	public string fall = "Nein ... Neeeiinn ... Ich kann nicht ...\n mein Traum zerfällt !!";

	private Text text;

	public string [] messages;

	public int counter = 0;

	private GameObject elements;

	private GameObject[] items;

	// Use this for initialization
	void Start () {
        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(-1);
        text = GetComponent<Text> ();

		elements = GameObject.Find ("/Elements");

		messages = new string[10];

		messages [0] = welcome;

		messages [1] = move;

		messages [2] = where;

		messages [3] = live;

		messages [4] = live2;

		messages [5] = live3;

		messages [6] = shadows;

		messages [7] = tip;

		messages [8] = collapse;

		InvokeRepeating ("count", 5f, 5f);
	}

	// Update is called once per frame
	void Update () {

	}

	public static GameObject[] getChildren(GameObject parent)
	{
		List<GameObject> items = new List<GameObject>();

		for (int i = 0; i < parent.transform.childCount; i++)
		{
			items.Add(parent.transform.GetChild(i).gameObject);

		}
		return items.ToArray();
	}


	public IEnumerator activateGravity () {

		items = getChildren (elements);

		GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ().useGravity = true;

		for (int i = 0; i < items.Length; i++) {

			yield return new WaitForSeconds(0.2f);

			items [i].GetComponent<Rigidbody> ().useGravity = true;
		}

        yield return new WaitForSeconds(2);

        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(2);

        LoadTargetSceneButton simulateButton = new LoadTargetSceneButton();
        PlayerPrefs.SetInt("2", 1);
        simulateButton.LoadSceneNum(2);
    }
		
	public void count () {

		if (counter < messages.Length) {

			text.text = messages [counter];

			counter ++;
		}

		if (counter >= messages.Length) {

			text.text = fall;

			StartCoroutine(activateGravity ());
		}
	}
}
