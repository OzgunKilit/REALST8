using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private GameObject leftFoot, rightFoot;
	public RelativeJoint2D leftJoint, rightJoint;
	public float speed; 
	// Use this for initialization
	void Start () {
		leftFoot = GameObject.Find ("LeftFoot");
		rightFoot =  GameObject.Find ("RightFoot");
		leftJoint = GameObject.Find("LeftHip").GetComponent<RelativeJoint2D>();
		rightJoint =  GameObject.Find("RightHip").GetComponent<RelativeJoint2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			//rightFoot.transform.position = (Vector2)rightFoot.transform.position + new Vector2(0.5f, 0 ) * Time.deltaTime;
			rightJoint.linearOffset += new Vector2(speed, 0 ) * Time.deltaTime;
			rightJoint.GetComponent<Rigidbody2D> ().MovePosition (rightJoint.linearOffset);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//rightFoot.linearOffset = rightFoot.linearOffset + new Vector2( 0.5f, 0 ) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			//rightFoot.transform.position = (Vector2)rightFoot.transform.position + new Vector2(0,1 ) * Time.deltaTime ;
			rightJoint.linearOffset += new Vector2( 0, speed ) * Time.deltaTime;
			rightJoint.GetComponent<Rigidbody2D> ().MovePosition (rightJoint.linearOffset);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			//rightFoot.transform.position = (Vector2)rightFoot.transform.position + new Vector2(0, -1 ) * Time.deltaTime;
			rightJoint.linearOffset -= new Vector2( 0, speed) * Time.deltaTime;
			rightJoint.GetComponent<Rigidbody2D> ().MovePosition (rightJoint.linearOffset);
		}
		
	
	}
}
