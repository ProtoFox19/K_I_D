using UnityEngine;
using System.Collections;

public class CamBehaviour : MonoBehaviour
{


    private Vector2 velocity;
    public float time_y;
    public float time_x;

    public GameObject player;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        float pos_x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, time_x) + 4f;
        float pos_y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, time_y);

        transform.position = new Vector3(pos_x, pos_y, transform.position.z);
    }
}
