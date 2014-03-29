using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization

	public long Points;
	public float range1, range2, MovementSpeed;
	bool alreadyGotPoint;
	float MovementDirrection, MovementSpeedTotal;
	GameObject Player;

	void Awake () {
		alreadyGotPoint = false;
		Player = GameObject.FindWithTag ("Player");

		if (transform.position.x > Player.transform.position.x)
			MovementDirrection = -1;
		else
			MovementDirrection = 1;
	}

	void OnCollisionEnter ( Collision collision ) {
		if (collision.collider.tag == "Player") {
			rigidbody.velocity = new Vector3(0, 0, 0);
			rigidbody.AddForce (new Vector3 ( MovementDirrection * MovementSpeedTotal, 0, 0), ForceMode.Impulse);
		}
	}

	public void Spawn ( ) {
		//increase movement per level
		Points = (long)Mathf.Pow (2f, (float)GameController.level - 1f );
		MovementSpeedTotal = MovementSpeed + (MovementSpeed * 20 / 100) * GameController.level;

		float smaller = Random.Range (0f, 5f);

		if (smaller < 1f) {
			float pos = gameObject.transform.position.y >= 0 ? 1f : -1f;
			gameObject.transform.localScale = new Vector3 ( 2, 2, 2 );
			transform.position = new Vector3 (transform.position.x, pos * 1.5f, transform.position.z );
		}
		else {
			gameObject.transform.localScale = new Vector3 ( 3, 3, 3 );
		}

		alreadyGotPoint = false;
		rigidbody.velocity = new Vector3(0, 0, 0);
		rigidbody.AddForce (new Vector3 ( MovementDirrection * MovementSpeedTotal, 0, 0), ForceMode.Impulse);
	}

	bool IsInRange () {
		if (range1 > range2) {
			range1 += range2;
			range2 = range1 - range2;
			range1 -= range2;
		}

		if (range1 <= transform.position.x && transform.position.x <= range2)
			return true;
		return false;
	}

	void LateUpdate () {
		if (!IsInRange ())
			gameObject.active = false;

		if (alreadyGotPoint == false)
			if (MovementDirrection > 0) {
				if (transform.position.x > Player.transform.position.x) {
					alreadyGotPoint = true;
					Score.IncreaseScore ( Points );
				}
			}
			else 
				if ( transform.position.x < Player.transform.position.x ) {
					alreadyGotPoint = true;
					Score.IncreaseScore ( Points );
				}
	}

}
