using UnityEngine;
using System.Collections;

public class Animations : MonoBehaviour {
	float ExplodeForce = 30f;
	float RotateSpeed = 400f, RotationLeft = 180f;
	float InitialX, InitialY, InitialZ;
	public GameObject Cube;
	public bool Dead = false;

	public void DeathAnimation ( ) {
		AudioController.Death ();

		Vector3[] Velocity = new Vector3[12];
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, 20f);

		Velocity[0] = new Vector3 ( 0f, 1f, 0f );
		Velocity[1] = new Vector3 ( 1f, 1f, 0f );
		Velocity[2] = new Vector3 ( 1.5f, 0.5f, 0f );
		Velocity[3] = new Vector3 ( 0.5f, 1.5f, 0f );
		Velocity[4] = new Vector3 ( 1f, 0f, 0f );
		Velocity[5] = new Vector3 ( 1f, -1f, 0f );
		Velocity[6] = new Vector3 ( 1.5f, -0.5f, 0f );
		Velocity[7] = new Vector3 ( 0.5f, -1.5f, 0f );
		Velocity[8] = new Vector3 ( -1f, -1f, 0f );
		Velocity[9] = new Vector3 ( -1.5f, -0.5f, 0f );
		Velocity[10] = new Vector3 ( -0.5f, -1.5f, 0f );
		Velocity[11] = new Vector3 ( 0, 0, 0f );


		for (long i = 0; i < 8; i++) {
			GameObject x = Instantiate (Cube, pos, Quaternion.Euler (0, 0, 0)) as GameObject;
			x.renderer.material.color = Color.white;
			x.rigidbody.AddForce ( Velocity[i] * ExplodeForce, ForceMode.Impulse );
		}

		for (long i = 8; i < 12; i++) {
			GameObject x = Instantiate (Cube, pos, Quaternion.Euler (0, 0, 0)) as GameObject;
			x.renderer.material.color = Color.green;
			x.rigidbody.AddForce (Velocity [i] * ExplodeForce, ForceMode.Impulse);
		}
	}

	public void Reset ( Transform NewTransform ) {
		gameObject.transform.position = NewTransform.position;
		gameObject.transform.rotation = NewTransform.rotation;
	}

	public void Kill ( ) {
		Dead = true;
		DeathAnimation ( );
	}

	public void Revive ( ) {
		Dead = false;
	}


	void OnCollisionEnter ( Collision collision ) {
		if (collision.collider.tag == "Monster")
			PlayersLifeController.KillAll ();
	}

	void Rotate ( ) {
		float rotate = RotateSpeed * Time.deltaTime;
		RotationLeft -= rotate;

		transform.eulerAngles = new Vector3 (InitialX, InitialY, transform.eulerAngles.z - rotate);
	}

	void Awake () {
		InitialX = transform.eulerAngles.x;
		InitialY = transform.eulerAngles.y;
		InitialZ = transform.eulerAngles.z;
	}

	void Update () {
		//jump animation
		if ( transform.position.y > 2.5f || transform.position.y < -2.5f ) {
			if ( RotationLeft > 0 )
				Rotate ();
			else
				transform.rotation = Quaternion.Euler (InitialX, InitialY, InitialZ);
		}
		else {
			RotationLeft = 180;
			transform.rotation = Quaternion.Euler (InitialX, InitialY, InitialZ);
		}
	}
}
