using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static bool TotalGameOver = true, TimeGameOver = true;
	public static float time = 0f;
	public static float deltaTime;
	static float LastRestartTime = 0f;
	public static GameObject God, AudioGod;

	public static void RestartGame () {
		TotalGameOver = false;
		TimeGameOver = false;
		
		//reset Players
		PlayersLifeController.ReviveAll ();

		LastRestartTime = Time.time;
		TimeScore.ResetTimeScore ();
		AudioController.StartGameMusic ();
		Time.timeScale = 1;
	}

	public static IEnumerator SetLevelOver () {
		TimeGameOver = true;
		
		bool ThereAreMonsters = true;
		while (ThereAreMonsters) {
			ThereAreMonsters = false;
			ThereAreMonsters = ThereAreMonsters | SpawnersLifeController.AreMonstersAlive () ;
			yield return new WaitForSeconds (0.1f);
		}

		Highscore.SetHighScore ( TimeScore.GetTimeScore () );
		TotalGameOver = true;
		AudioController.StartMenuMusic ();
		yield return new WaitForSeconds (1.5f);

		Level.ResetLevel ();
		Score.ResetScore ();
		Time.timeScale = 0;
		
		GameObject.Find("Play").GetComponent<PlayGame>().Show ();
	}

	public void LevelOver () {
		StartCoroutine (SetLevelOver ());
	}

	public static void GameOver () {
		God.GetComponent<GameController>().LevelOver ();
	}



	public static void SetDeltaTime () {
		if (Time.deltaTime > 0)
			deltaTime = Time.deltaTime;
	}


	void Update () {
		time = Time.time - LastRestartTime;
	}

	void Start () {
		AudioController.StartMenuMusic ();
		Time.timeScale = 0;
	}

	void Awake () {
		God = gameObject;
		AudioGod = GameObject.Find ( "AudioGod" );
		Screen.showCursor = true;
		SetDeltaTime ();
	}
}
