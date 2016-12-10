using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	private HipController left, right;
	private StickyFeet leftFoot, rightFoot;
	// Use this for initialization
	void Start () {
		left = GameObject.Find ("LeftHip").GetComponent<HipController> ();
		right = GameObject.Find ("RightHip").GetComponent<HipController> ();
		//leftFoot = GameObject.Find ("LeftFoot").GetComponent<StickyFeet> ();
		//rightFoot = GameObject.Find ("LeftFoot").GetComponent<StickyFeet> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			right.targetDistance -= 0.1f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			right.targetDistance += 0.1f;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			right.targetAngle += 3f;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			right.targetAngle -= 3f;
		}
		if (Input.GetKey (KeyCode.W)) {
			left.targetDistance -= 0.1f;
		}
		if (Input.GetKey (KeyCode.S)) {
			left.targetDistance += 0.1f;
		}
		if (Input.GetKey (KeyCode.A)) {
			left.targetAngle += 3f;
		}
		if (Input.GetKey (KeyCode.D)) {
			left.targetAngle -= 3f;
		}
	}
}
