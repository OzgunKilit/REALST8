using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public WheelJoint2D leftWheelJoint, rightWheelJoint;
	private JointMotor2D jointMotor;

	public float motorSpeed = 300;

	// Use this for initialization
	void Start () {
		jointMotor = leftWheelJoint.motor;
	}

	// Update is called once per frame
	void FixedUpdate () {

		jointMotor.motorSpeed = 0;
		leftWheelJoint.motor = jointMotor;
		jointMotor.motorSpeed = 0;
		rightWheelJoint.motor = jointMotor;


		if (Input.GetKey (KeyCode.RightArrow)) {
			jointMotor.motorSpeed = motorSpeed;
			rightWheelJoint.motor = jointMotor;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			jointMotor.motorSpeed = -motorSpeed;
			rightWheelJoint.motor = jointMotor;
		}
		if (Input.GetKey (KeyCode.D)) {
			jointMotor.motorSpeed = motorSpeed;
			leftWheelJoint.motor = jointMotor;
		}
		if (Input.GetKey (KeyCode.A)) {
			jointMotor.motorSpeed = -motorSpeed;
			leftWheelJoint.motor = jointMotor;
		}


	}
}
