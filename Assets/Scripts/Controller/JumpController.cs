using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {
	public float jumpForce;
	public KeyCode jumpkey;
	public AudioClip JumpingSound;
	float TerrainPosition;

	public bool grounded;
	private bool jump, startJump;

	public void ResetScript () {
		jump = startJump = false;
		TerrainPosition = -1 * gameObject.GetComponent<Gravity> ().GravityForce > 0 ? 1 : -1;
		grounded = true;
		rigidbody.velocity = new Vector3 (0, 0, 0);
	}


	// Use this for initialization
	void Start () {
		ResetScript ();
	}

	void OnCollisionEnter ( Collision col ) {
		if (col.collider.tag == "Terrain" ) {
			grounded = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( grounded && jump == false && InputController.GetInput ( TerrainPosition ) ) {
			jump = true;
			startJump = true;
			grounded = false;
		}
	}

	void falseJump (  ) {
		jump = false;
	}

	void FixedUpdate () {
		if (startJump) {
			startJump = false;
			Invoke ( "falseJump", 0.1f );

			AudioController.Jump ();
			rigidbody.AddForce ( new Vector3 ( 0, TerrainPosition * jumpForce, 0 ), ForceMode.Impulse );
		}
	}
}
