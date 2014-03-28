using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public static AudioClip JumpSound, DeathSound, MenuMusic, GameMusic;

	public static void Jump () {
		AudioPool.PlayAudioClip ( JumpSound );
	}

	public static void Death () {
		AudioPool.PlayAudioClip (DeathSound);
	}

	public static void StartMenuMusic () {
		AudioPool.SetBackgroundMusic (MenuMusic);
	}

	public static void StartGameMusic () {
		AudioPool.SetBackgroundMusic (GameMusic);
	}



	void Start () {
		GameObject AudioGod = GameController.AudioGod;

		JumpSound = AudioGod.GetComponent<AudioFiles> ().JumpSound;
		DeathSound = AudioGod.GetComponent<AudioFiles> ().DeathSound;
		MenuMusic = AudioGod.GetComponent<AudioFiles> ().MenuMusic;
		GameMusic = AudioGod.GetComponent<AudioFiles> ().GameMusic;
	}

	void Update () {
	}
}
