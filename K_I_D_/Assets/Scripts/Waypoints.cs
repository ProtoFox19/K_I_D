using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	// Speicher für die Punkte
	public Transform[] wayPoint;

	public int currentWayPoint = 0;
	Transform targetWayPoint;

	public float speed = 4f;

	bool reachedEnd = false;

	// Use this for initialization
	void Start () {

		// Verbindung zum Mesh Renderer
		MeshRenderer mesh = GetComponent<MeshRenderer> ();

		// Beim Starten nur Schatten zeigen
		mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
	}

	// Update is called once per frame
	void Update () {

		// Solange der letzte Waypoint nicht erreicht ist
		if(reachedEnd == false) {
			if(targetWayPoint == null)
				targetWayPoint = wayPoint[currentWayPoint];

			walk();
		}

		// Solange der erste Waypoint nicht erreicht ist
		if(reachedEnd == true) {
			if(targetWayPoint == null)
				targetWayPoint = wayPoint[currentWayPoint - 1];

			walk();
		}
	}

	void walk() {
		// Ausrichten des Objekts mittels Rotate
		//transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);

		// Bewegen zum Ziel
		transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed*Time.deltaTime);

		if((transform.position == targetWayPoint.position) && reachedEnd == false) {
			if (!(currentWayPoint == 5)) {

				currentWayPoint ++ ;
				targetWayPoint = wayPoint[currentWayPoint];

			} else {

				reachedEnd = true;
			}
		}

		if((transform.position == targetWayPoint.position) && reachedEnd == true) {

			if (!(currentWayPoint == 0)) {

				currentWayPoint -- ;
				targetWayPoint = wayPoint[currentWayPoint];

			} else {

				reachedEnd = false;
			}
		}
	}
}
