using UnityEngine;
using System.Collections;

public class CamBehaviour : MonoBehaviour
{
	private Vector2 velocity;
    public float time_y;
    public float time_x;

    public GameObject player;

	private float transition = 0.0f;
	public float animationDuration = 8.0f;

	// Level Animation
	private Vector3 animationOffset;

	public bool level2 = false;
	public bool level1 = false;

	private Vector3 moveVector;

    // Use this for initialization
    void Start()
    {

		if (level1 == true) {
			animationOffset = new Vector3 (0, 0, -40);
		}

		if (level2 == true) {
			animationOffset = new Vector3 (300, 15, -120);
		}

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float pos_x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, time_x) + 4f;
        float pos_y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, time_y);

		// Eigentliche Kameraposition
		moveVector = new Vector3(pos_x, pos_y, -16);

		if (transition < 1.0f) {

			transform.position = Vector3.Lerp (moveVector + animationOffset, moveVector, transition);

			transition += Time.deltaTime * 1 / animationDuration;

		} else {

			transform.position = new Vector3(pos_x, pos_y, transform.position.z);

		}
    }
}
