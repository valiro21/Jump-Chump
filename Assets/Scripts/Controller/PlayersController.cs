using UnityEngine;
using System.Collections;

public class PlayersController : MonoBehaviour {

	public static GameObject[] Players;
	static Transform[] PlayersInitialTransform;

	public static void Kill ( GameObject Player, Transform NewTransform ) {
		Player.GetComponent<Animations> ().Kill ();
		Player.GetComponent<Animations> ().Reset ( NewTransform );
		Player.active = false;
	}

	public static void KillAll () {
		for (long i = 0; i < Players.Length; i++)
			Kill (Players[i], PlayersInitialTransform[i]);
		
		GameController.GameOver ();
	}


	public static void ReviveAll () {
		for (long i = 0; i < Players.Length; i++) {
			Players[i].active = true;
			Players[i].GetComponent<Animations> ().Revive ();
			Players[i].GetComponent<JumpController>().ResetScript ();
		}
	}


	void Awake () {
		Players = GameObject.FindGameObjectsWithTag ( "Player" );
		PlayersInitialTransform = new Transform[Players.Length];

		for (long i = 0; i < Players.Length; i++)
			PlayersInitialTransform[i] = Players[i].transform;
	}

}
