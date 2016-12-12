using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	LevelManager levelManager;

	public float partScale = 0.1f;
	void Start()
	{
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.relativeVelocity.magnitude >= 5) {
			
			switch (this.gameObject.name) {

			case "Head":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "Torso":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "LeftUpperArm":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "LeftLowerArm":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "RightUpperArm":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "RightLowerArm":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "LeftUpperLeg":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "LeftLowerLeg":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "LeftFoot":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "RightUpperLeg":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "RightLowerLeg":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			case "RightFoot":
				levelManager.health -= coll.relativeVelocity.magnitude * partScale;
				break;
			default:
				break;
			}

			if (levelManager.health < 0) {
				levelManager.health = 0;
			}
		}
	}
}
