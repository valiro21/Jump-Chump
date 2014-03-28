using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	static float highscore = 0.0f;
	TextMesh textMesh;

	public static void SetHighScore ( float score ) {
		if ( score > GetHighScore () )
			PlayerPrefs.SetFloat ("Highscore", score );
	}

	public static float GetHighScore ( ) {
		return PlayerPrefs.GetFloat ("Highscore");
	}
	
	// Update is called once per frame
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh> ();
	}

	void FixedUpdate () {
		textMesh.text = GetHighScore ( ).ToString( "f1" );
	}
}
