using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Intro : MonoBehaviour {

	public string welcome;

	public string move;

	public string where;

	public string live;

	public string live2;

	public string live3;

    public string live4;

    public string shadows;

    public string shadows2;

    public string tip;

    public string tip2;

    public string collapse;

    public string collapse2;

    public string fall;

	private Text text;

	public string [] messages;

	public int counter = 0;

	private GameObject elements;

	private GameObject[] items;

    bool go = false;

    // Use this for initialization
    void Start () {
        GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(-1);
        text = GetComponent<Text> ();
        text.color = new Color(0f, 0f, 0f, 0.8f);

		elements = GameObject.Find ("/Elements");

		messages = new string[13];
        
        messages [0] = welcome;

		messages [1] = move;

		messages [2] = where;

		messages [3] = live;

		messages [4] = live2;

		messages [5] = live3;

        messages[6] = live4;

        messages [7] = shadows;

        messages[8] = shadows2;

        messages [9] = tip;

        messages[10] = tip2;

        messages [11] = collapse;

        messages[12] = collapse2;

        InvokeRepeating ("count", 3f, 3f);
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

			yield return new WaitForSeconds(0.15f);

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

        if (go)
        {

            text.text = fall;

            StartCoroutine(activateGravity());
        }

        if (counter < messages.Length) {
			text.text = messages [counter];
            counter++;
            if (counter >= 13) go = true;
        }

		
	}
}
