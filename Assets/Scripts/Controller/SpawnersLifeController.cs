using UnityEngine;
using System.Collections;

public class SpawnersLifeController : MonoBehaviour {

	public static bool IsSpawnerEnabled ( GameObject Spawner ) {
		return Spawner.GetComponent<SpawnPool>().IsEnabled ();
	}

	public static bool AreMonstersAlive () {
		GameObject[] Spawners = GameObject.FindGameObjectsWithTag ( "Spawner" );
		
		foreach (GameObject Spawner in Spawners)
			if (Spawner.GetComponent<SpawnPool> ().AreMonstersAlive ())
				return true;
		
		return false;
	}
}
