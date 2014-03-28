using UnityEngine;
using System.Collections;

public class SpawnPool : MonoBehaviour {

	public float NumerOfObjectsInPool, MinSpawnInterval, MaxSpawnInterval, MaxSpawnObjects, MultipleObjectsSpawnInterval;
	public Object PoolObject;
	public float SpawnEnableLevel;

	bool Enabled = false;
	GameObject[] PoolObjects;

	void Enable ( ) {
		Enabled = true;
		StartCoroutine("Spawn");
	}

	public void Disable () {
		StopCoroutine("Spawn");
		Enabled = false;
	}


	public bool IsEnabled () {
		return Enabled;
	}

	public bool AreMonstersAlive () {
		for ( long i = 0; i < (int)NumerOfObjectsInPool; i++)
			if ( PoolObjects[i].active == true )
				return true;
		return false;
	}



	float SpawnInterval () {
		return Random.Range (MinSpawnInterval, MaxSpawnInterval);
	}

	IEnumerator Spawn () {
		long NumberOfObjectsToSpawn = (long)Random.Range ( 1f, MaxSpawnObjects );
		float Interval = MultipleObjectsSpawnInterval / NumberOfObjectsToSpawn;

		for ( long i = 0; i < NumberOfObjectsToSpawn; i++ ) {
			SpawnObject ();
			yield return new WaitForSeconds(Interval);
		}

		yield return new WaitForSeconds(SpawnInterval ( ) );
		StartCoroutine("Spawn");
	}

	void SpawnObject ( ) {
		for ( long i = 0; i < (int)NumerOfObjectsInPool; i++) {
			if ( PoolObjects[i].active == false ) {
				PoolObjects[i].transform.position = transform.position;
				PoolObjects[i].active = true;
				PoolObjects[i].GetComponent<EnemyMovement>().Spawn ( );
				break;
			}
		}
	}



	void Awake () {
		PoolObjects = new GameObject[(int)NumerOfObjectsInPool];
		
		for ( long i = 0; i < (int)NumerOfObjectsInPool; i++) {
			PoolObjects[i] = Instantiate ( PoolObject, transform.position, transform.rotation ) as GameObject;
			PoolObjects[i].active = false;
		}
	}

	void Update () {
		if (Level.level == (long)SpawnEnableLevel && !Enabled && !GameController.TimeGameOver )
			Enable ();

		if (GameController.TimeGameOver)
			Disable ();
	}
}
