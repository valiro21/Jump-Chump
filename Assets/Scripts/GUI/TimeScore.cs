using UnityEngine;
using System.Collections;

public class TimeScore : MonoBehaviour {

	static float timescore;

	public static float GetTimeScore () {
		return timescore;
	}

	public static void ResetTimeScore () {
		timescore = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if ( !GameController.TimeGameOver ) {
			timescore = GameController.time;
			gameObject.GetComponent<TextMesh>().text = timescore.ToString( "f1" );
		}
	}
}
