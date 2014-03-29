using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	public static KeyCode JumpJumpKey = KeyCode.UpArrow, ChumpJumpKey = KeyCode.DownArrow;

	public static bool GetTouchInput ( float position ) {
		if (GameController.time < 0.3f)
			return false;

		for ( int i = 0; i < Input.touchCount; i++ ) {
			Touch tscr =  Input.GetTouch ( i );
			if ( position > 0 && tscr.position.y > Screen.height / 2 || position < 0 && tscr.position.y < Screen.height / 2 )
				return true;
		}
		
		return false;
	}

	public static bool GetKeyboardInput ( float position ) {
		if (position > 0)
			return Input.GetKey (JumpJumpKey);
		else
			return Input.GetKey (ChumpJumpKey);
	}

	public static bool GetInput ( float position ) {
		return GetKeyboardInput (position) | GetTouchInput (position);
	}
}
