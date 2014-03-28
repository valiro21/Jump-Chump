using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	public static long score = 0;

	public static void ResetScore () {
		score = 0;
	}

	public static void IncreaseScore ( long x ) {
		score += x;
	}

	void FixedUpdate () {
		gameObject.GetComponent<TextMesh>().text = score.ToString();
	}
}
