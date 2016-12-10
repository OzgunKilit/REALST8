using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipController : MonoBehaviour {
	public float targetAngle;
	public float targetDistance;

	private HingeJoint2D hinge;
	private SliderJoint2D slider;

	// Use this for initialization
	void Start () {
		hinge = GetComponent<HingeJoint2D> ();
		slider = GetComponent<SliderJoint2D> ();

		targetAngle = hinge.jointAngle;
		targetDistance = slider.jointTranslation;
	}

	// Update is called once per frame
	void Update () {
		targetDistance = Mathf.Clamp (targetDistance, slider.limits.min, slider.limits.max);
		targetAngle = Mathf.Clamp (targetAngle, hinge.limits.min, hinge.limits.max);

		JointMotor2D hingeMotor = hinge.motor;
		hingeMotor.motorSpeed = (targetAngle - hinge.jointAngle) * 100 * Time.deltaTime;
		hinge.motor = hingeMotor;

		JointMotor2D sliderMotor = slider.motor;
		sliderMotor.motorSpeed = (targetDistance - slider.jointTranslation) * 100 * Time.deltaTime;
		slider.motor = sliderMotor;
		//Debug.Log ("delta: " + (targetDistance - slider.jointTranslation) + " cur: " + slider.jointTranslation);
	}
}
