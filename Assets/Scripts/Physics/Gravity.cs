using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public float GravityForce;

	// Use this for initialization
	void Awake ( ) {
		if ( gameObject.GetComponent<Rigidbody>() == null )
			gameObject.AddComponent ("Rigidbody");
	}


	void Start () {
		rigidbody.useGravity = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.AddForce (new Vector3 (0, GravityForce, 0), ForceMode.Acceleration);
	}
}
