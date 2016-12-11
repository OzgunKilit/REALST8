using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float health = 100;

	private Text currentHealthText;
	// Use this for initialization
	void Start () {
		currentHealthText = GameObject.Find ("CurrentHealth").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int currentHealth = int.Parse (currentHealthText.text);
		currentHealth = (int)health;
		currentHealthText.text = currentHealth.ToString ();

		
	}
}
