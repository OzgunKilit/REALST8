using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public WheelJoint2D leftWheelJoint, rightWheelJoint;
	private JointMotor2D leftJointMotor, rightJointMotor;
	private Vector2 leftAnchor, rightAnchor;

	private Rigidbody2D roomRigidbody;

	public float motorSpeed = 300;
	public float maxSpeed = 500;
	public float jumpSpeed = 10000;

	public bool didFallOver = false;
	public bool didWin = false;
	public Transform leftWallGroundCheck, rightWallGroundCheck, topWallGroundCheck;

	public bool extended = false;

	public bool isLeftLegGrounded, isRightLegGrounded;
	public Transform leftLegGroundCheck, rightLegGroundCheck;

	void Start () {
		leftJointMotor = leftWheelJoint.motor;
		rightJointMotor = rightWheelJoint.motor;

		roomRigidbody = GameObject.Find ("oneroom").GetComponent<Rigidbody2D>();

		leftAnchor = GameObject.Find ("LeftWheelPos").transform.localPosition;
		rightAnchor = GameObject.Find ("RightWheelPos").transform.localPosition;
		if (extended) {
			leftWheelJoint.connectedAnchor = leftAnchor; // GameObject.Find ("LeftHip").transform.localPosition;
			rightWheelJoint.connectedAnchor = rightAnchor; // GameObject.Find ("RightHip").transform.localPosition;
		} else {
			leftWheelJoint.GetComponent<LineRenderer>().enabled = false;
			rightWheelJoint.GetComponent<LineRenderer>().enabled = false;
		}
	}

	void FixedUpdate () {
		if (!extended) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				extended = true;

				leftWheelJoint.GetComponent<LineRenderer>().enabled = true;
				rightWheelJoint.GetComponent<LineRenderer>().enabled = true;
			}

			return;
		}

		// extend legs if not extended
		if (leftWheelJoint.connectedAnchor != leftAnchor)
			leftWheelJoint.connectedAnchor += (leftAnchor - leftWheelJoint.connectedAnchor) / 10;
		if (rightWheelJoint.connectedAnchor != rightAnchor)
			rightWheelJoint.connectedAnchor += (rightAnchor - rightWheelJoint.connectedAnchor) / 10;
		else if (didWin) {
			leftWheelJoint.GetComponent<LineRenderer>().enabled = false;
			rightWheelJoint.GetComponent<LineRenderer>().enabled = false;
		}
		
		if ( (Physics2D.Linecast(transform.position, leftLegGroundCheck.position, 1 << LayerMask.NameToLayer("Target"))
			&& Physics2D.Linecast(transform.position, rightLegGroundCheck.position, 1 << LayerMask.NameToLayer("Target")))
			|| Physics2D.Linecast (transform.position, topWallGroundCheck.position, 1 << LayerMask.NameToLayer ("Target"))) {
			leftAnchor = GameObject.Find ("LeftHip").transform.localPosition;
			rightAnchor = GameObject.Find ("RightHip").transform.localPosition;
			leftWheelJoint.GetComponent<CircleCollider2D>().enabled = false;
			rightWheelJoint.GetComponent<CircleCollider2D>().enabled = false;
			didWin = true;
			return;
		}

		isLeftLegGrounded = Physics2D.Linecast(transform.position, leftLegGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		isRightLegGrounded = Physics2D.Linecast(transform.position, rightLegGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		// check if house fell over
		if (Physics2D.Linecast (transform.position, leftWallGroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"))
		    || Physics2D.Linecast (transform.position, rightWallGroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"))
		    || Physics2D.Linecast (transform.position, topWallGroundCheck.position, 1 << LayerMask.NameToLayer ("Ground"))) {
			didFallOver = true;
		} 
		else {
			didFallOver = false;
		}


		// reset scene on R
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (0);
		}

		float rightCtrl = 0;
		if (Input.GetKey (KeyCode.LeftArrow))
			rightCtrl -= 1;
		if (Input.GetKey (KeyCode.RightArrow))
			rightCtrl += 1;
		if (Input.GetKeyDown (KeyCode.UpArrow) && isRightLegGrounded) {
			isRightLegGrounded = false;
			roomRigidbody.AddForceAtPosition ((Vector2)transform.up*jumpSpeed,rightLegGroundCheck.transform.position, ForceMode2D.Force);
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
		if (Input.GetKeyDown (KeyCode.W) && isLeftLegGrounded) {
			isLeftLegGrounded = false;
			roomRigidbody.AddForceAtPosition ((Vector2)transform.up*jumpSpeed,leftLegGroundCheck.transform.position, ForceMode2D.Force);
		}
		leftJointMotor.motorSpeed = Mathf.Clamp (leftJointMotor.motorSpeed + leftCtrl * maxSpeed * Time.fixedDeltaTime, -maxSpeed, maxSpeed);

		if (leftCtrl == 0)
			leftJointMotor.motorSpeed *= 0.9f;
		if (Mathf.Abs(leftJointMotor.motorSpeed) < 10)
			leftJointMotor.motorSpeed = 0;
		leftWheelJoint.motor = leftJointMotor;
	}
}
