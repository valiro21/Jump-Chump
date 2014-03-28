using UnityEngine;
using System.Collections;

//For this script to work you need to have a script named IncreasingLevel
//with a function IncreaseLevel, where you level up the level of spawning monsters,
//attached to the game spawners


public class Level : MonoBehaviour {
	public float LevelTime;
	public string SpawnerTag;
	public static long level = 1;

	TextMesh textMesh;
	long second, prevSecond;
	GameObject[] spawners;

	public static void ResetLevel () {
		level = 1;
	}

	// Use this for initialization
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		//increasing difficulty
		second = (long)GameController.time;
		if (second > 0 && second % (long)LevelTime == 0 && second != prevSecond)
			level++;
		prevSecond = second;
	}

	void FixedUpdate () {
		textMesh.text = level.ToString();
	}
}
