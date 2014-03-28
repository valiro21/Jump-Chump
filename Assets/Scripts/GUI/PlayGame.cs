using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	float speed = 2f;
	Vector3 newScale = new Vector3 ( 60, 1, 4 );
	Vector3 oldScale = new Vector3 ( 35, 1, 4 );

	void OnMouseDown () {
		Screen.showCursor = false;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;

		GameController.RestartGame ();
	}

	void Update () {
		if ( !GameController.TotalGameOver )
			GameObject.FindGameObjectWithTag ("Terrain").transform.localScale = Vector3.Lerp (GameObject.FindGameObjectWithTag ("Terrain").transform.localScale, newScale, speed * Time.deltaTime);
		else
			GameObject.FindGameObjectWithTag ("Terrain").transform.localScale = Vector3.Lerp (GameObject.FindGameObjectWithTag ("Terrain").transform.localScale, oldScale, speed * Time.deltaTime);
	}

	public void Show () {
		Screen.showCursor = true;
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<BoxCollider> ().enabled = true;
	}
}
