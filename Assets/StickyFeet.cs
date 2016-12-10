using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFeet : MonoBehaviour {
	public bool grab;
	private FixedJoint2D joint;

	void Start () {
		joint = GetComponent<FixedJoint2D> ();
		joint.enabled = false;
	}
		
	void Update () {
		if (!grab) {
			joint.enabled = false;
		} else if (!joint.enabled) {
			Vector2 anchorPos = transform.TransformPoint (joint.anchor);
			foreach (Collider2D hit in Physics2D.OverlapPointAll (anchorPos)) {
				joint.connectedBody = hit.attachedRigidbody;
				joint.enabled = true;
				break;
			}
		}
	}
}
