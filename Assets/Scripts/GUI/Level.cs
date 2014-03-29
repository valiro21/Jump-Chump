using UnityEngine;
using System.Collections;

//For this script to work you need to have a script named IncreasingLevel
//with a function IncreaseLevel, where you level up the level of spawning monsters,
//attached to the game spawners


public class Level : MonoBehaviour {
	TextMesh textMesh;


	// Use this for initialization
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh> ();
	}

	void FixedUpdate () {
		textMesh.text = GameController.level.ToString();
	}
}
