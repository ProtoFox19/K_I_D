using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {

    public virtualJoystick moveJoystick;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate() {
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
}
