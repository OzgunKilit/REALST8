using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

	private Movement movementScript;

	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		movementScript = GameObject.Find ("oneroom").GetComponent<Movement> ();
		textMesh = GameObject.Find ("TextMesh").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (movementScript.didFallOver) {
			textMesh.text = "PRESS R TO RESET!";
		} else if (!movementScript.extended) {
			textMesh.text = "PRESS SPACE TO START!";
		}
		else {
			textMesh.text = "";
		}
		
	}
}
