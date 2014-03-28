using UnityEngine;
using System.Collections;

public class BackgroundAnimation : MonoBehaviour {

	long NumberOfStripes = 41;
	GameObject[] PoolObjects;
	public GameObject Stripe;
	public float SizeOfStripes = 3f;

	// Use this for initialization
	void Start () {
		NumberOfStripes = (long)(120f / SizeOfStripes) + 1;

		PoolObjects = new GameObject[NumberOfStripes];
		
		for ( long i = 0; i < NumberOfStripes; i++) {
			PoolObjects[i] = Instantiate ( Stripe, new Vector3 ( -60 + i * SizeOfStripes, 0, 12 ), Quaternion.Euler ( 0, 0, 45 ) ) as GameObject;
			if ( i % 2 > 0 )
				PoolObjects[i].GetComponent<BackgroundColor>().MaxChannel = 0;
			else
				PoolObjects[i].GetComponent<BackgroundColor>().MaxChannel = 1;
		}
	}
}
