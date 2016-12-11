using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public WheelJoint2D leftWheelJoint, rightWheelJoint;
	private JointMotor2D jointMotor;
	private JointMotor2D leftJointMotor, rightJointMotor;

	private Rigidbody2D roomRigidbody;

	public float motorSpeed = 300;
	public float maxSpeed = 500;

	void Start () {
		jointMotor = leftWheelJoint.motor;
		leftJointMotor = leftWheelJoint.motor;
		rightJointMotor = rightWheelJoint.motor;

		roomRigidbody = GameObject.Find ("oneroom").GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float rightCtrl = 0;
		if (Input.GetKey (KeyCode.LeftArrow))
			rightCtrl -= 1;
		if (Input.GetKey (KeyCode.RightArrow))
			rightCtrl += 1;
		if (Input.GetKeyDown (KeyCode.Space)) {
			roomRigidbody.AddForce (new Vector2(0,20000), ForceMode2D.Force);
		}

		rightJointMotor.motorSpeed = Mathf.Clamp (rightJointMotor.motorSpeed + rightCtrl  * maxSpeed * Time.fixedDeltaTime, -maxSpeed, maxSpeed);

		if (rightCtrl == 0)
			rightJointMotor.motorSpeed *= 0.9f;
		if (Mathf.Abs(rightJointMotor.motorSpeed) < 10)
			rightJointMotor.motorSpeed = 0;
		rightWheelJoint.motor = rightJointMotor;

		float leftCtrl = 0;
		if (Input.GetKey (KeyCode.A))
			leftCtrl -= 1;
		if (Input.GetKey (KeyCode.D))
			leftCtrl += 1;
		leftJointMotor.motorSpeed = Mathf.Clamp (leftJointMotor.motorSpeed + leftCtrl * maxSpeed * Time.fixedDeltaTime, -maxSpeed, maxSpeed);

		if (leftCtrl == 0)
			leftJointMotor.motorSpeed *= 0.9f;
		if (Mathf.Abs(leftJointMotor.motorSpeed) < 10)
			leftJointMotor.motorSpeed = 0;
		leftWheelJoint.motor = leftJointMotor;
	}
}
