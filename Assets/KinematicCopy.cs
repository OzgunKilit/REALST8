using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicCopy : MonoBehaviour {
	public Rigidbody2D originalBody;
	private Rigidbody2D ownBody;

	void Start () {
		ownBody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		ownBody.MovePosition (originalBody.transform.position);
		ownBody.MoveRotation (originalBody.transform.rotation.eulerAngles.z);
	}
}