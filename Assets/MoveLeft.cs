using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		JointMotor2D jointMotor = this.GetComponent<WheelJoint2D>().motor;
		jointMotor.motorSpeed = 500f;
		this.GetComponent<WheelJoint2D>().motor = jointMotor;
	}
}
