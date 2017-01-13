using UnityEngine;
using System.Collections;

public class DreieckBewegung : MonoBehaviour {

    private float time;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (pos.x >= 818)
        {
            pos.x -= 9f * Time.deltaTime;
        }
        else
        {
            pos.x = 825;
        }
        transform.position = pos;
        Debug.Log(pos);
    }


}
