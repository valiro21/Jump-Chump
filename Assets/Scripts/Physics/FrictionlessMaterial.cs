using UnityEngine;
using System.Collections;

public class FrictionlessMaterial : MonoBehaviour {

	private float LockedX, LockedY, LockedZ, LockedRX, LockedRY, LockedRZ;

	// Use this for initialization

	void Awake ( ) {
		if (tag == "Monster") {
			if ( gameObject.GetComponent<Rigidbody>() ==  null )
				gameObject.AddComponent ("Rigidbody");

			rigidbody.useGravity = false;
		}
	}

	void Start () {
		LockedRZ = transform.rotation.z;
	}

	void FixedUpdate ( ) {
		if (gameObject.tag == "Player") {
			//transform.position = new Vector3 (LockedX, transform.position.y, LockedZ);
			//transform.rotation = Quaternion.Euler ( LockedRX, LockedRY, transform.rotation.z );
		}
	}
}
