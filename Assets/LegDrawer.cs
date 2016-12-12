using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDrawer : MonoBehaviour {
	public Transform hip, foot;

	private Vector2 knee, velocity;
	private LineRenderer lines;

	void Start () {
		lines = GetComponent<LineRenderer> ();
		knee = getOptimalPosition ();
	}

	Vector2 getOptimalPosition() {
		return (hip.position + foot.position)/2;
	}

	void Update () {
		velocity += (getOptimalPosition () - knee)*0.8f;
		knee += velocity * Time.deltaTime;
		velocity *= 0.9f;

		Vector3 a = hip.position;
		Vector3 b = knee;
		Vector3 c = foot.position;

		for (int i = 0; i < lines.numPositions; i++)
			lines.SetPosition (i, Bezier.GetPoint(a, b, b, c, i / (float)(lines.numPositions-1)));
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (knee, 0.05f);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (hip.position, 0.05f);
		Gizmos.DrawWireSphere (getOptimalPosition(), 0.05f);
		Gizmos.DrawWireSphere (foot.position, 0.05f);
	}
}
