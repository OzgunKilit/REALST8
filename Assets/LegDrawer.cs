using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDrawer : MonoBehaviour {
	public Rigidbody2D house;
	public Vector2 hip, foot;

	private Vector2 knee, velocity;
	private LineRenderer lines;

	void Start () {
		lines = GetComponent<LineRenderer> ();

		hip = house.transform.InverseTransformPoint (hip);
		foot = transform.InverseTransformPoint (foot);

		knee = getOptimalPosition ();
	}

	Vector2 getOptimalPosition() {
		return (house.transform.TransformPoint(hip) + transform.TransformPoint(foot))/2;
	}

	void Update () {
		velocity += (getOptimalPosition () - knee)*0.8f;
		knee += velocity * Time.deltaTime;
		velocity *= 0.9f;

		Vector3 a = house.transform.TransformPoint (hip);
		Vector3 b = knee; //getOptimalPosition ();
		Vector3 c = transform.TransformPoint (foot);

		for (int i = 0; i < lines.numPositions; i++)
			lines.SetPosition (i, Bezier.GetPoint(a, b, b, c, i / (float)(lines.numPositions-1)));
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (knee, 0.05f);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (house.transform.TransformPoint(hip), 0.05f);
		Gizmos.DrawWireSphere (getOptimalPosition(), 0.05f);
		Gizmos.DrawWireSphere (transform.TransformPoint(foot), 0.05f);
	}
}
