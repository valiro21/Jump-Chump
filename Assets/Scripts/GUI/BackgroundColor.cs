using UnityEngine;
using System.Collections;

public class BackgroundColor : MonoBehaviour {

	public long MaxChannel;
	public long MoveSpeed = 6;
	public bool Enabled = true;

	Color NewColor;
	Color[] LightColor, DarkColor;
	long mode;
	float smooth = 2f;
	float r, g, b, tm;
	
	// Update is called once per frame
	void AnimationUpdate () {

		Color tmp = renderer.material.color;

		if ( MaxChannel == 0 ) {
			for ( long j = 0; j < 6; j++ )
				if ( tmp == LightColor[j] ) {
					long newInd = (j + 1) % 6;
					NewColor = LightColor[newInd];
				}
		}
		else
			for ( long j = 0; j < 6; j++ )
				if ( tmp == DarkColor[j] ) {
					long newInd = (j + 1) % 6;
					NewColor = DarkColor[newInd];
				}

		renderer.material.color = Color.Lerp ( renderer.material.color, NewColor , smooth * tm );
	}

	void Start () {
		SetColors ();

		if ( MaxChannel == 0 )
			renderer.material.color = NewColor = LightColor[0];
		else
			renderer.material.color = NewColor = DarkColor[0];
	}

	void SetColors () {
		LightColor = new Color[6];
		DarkColor = new Color[6];

		LightColor[0] = new Color ( 255.0f/255.0f, 0.0f/255.0f, 0.0f/255.0f );
		LightColor[1] = new Color ( 255.0f/255.0f, 174.0f/255.0f, 0.0f/255.0f );
		LightColor[2] = new Color ( 255.0f/255.0f, 255.0f/255.0f, 0.0f/255.0f );
		LightColor[3] = new Color ( 0.0f/255.0f, 255.0f/255.0f, 0.0f/255.0f );
		LightColor[4] = new Color ( 0.0f/255.0f, 0.0f/255.0f, 255.0f/255.0f );
		LightColor[5] = new Color ( 174.0f/255.0f, 0.0f/255.0f, 255.0f/255.0f );

		DarkColor[0] = new Color ( 135.0f/255.0f, 38.0f/255.0f, 38.0f/255.0f );
		DarkColor[1] = new Color ( 135.0f/255.0f, 104.0f/255.0f, 38.0f/255.0f );
		DarkColor[2] = new Color ( 135.0f/255.0f, 135.0f/255.0f, 38.0f/255.0f );
		DarkColor[3] = new Color ( 38.0f/255.0f, 135.0f/255.0f, 38.0f/255.0f );
		DarkColor[4] = new Color ( 38.0f/255.0f, 62.0f/255.0f, 135.0f/255.0f );
		DarkColor[5] = new Color ( 104.0f/255.0f, 38.0f/255.0f, 135.0f/255.0f );
	}

	void Update () {
		tm = Time.deltaTime > 0 ? Time.deltaTime : GameController.deltaTime;

		if (transform.position.x < 61f)
			transform.position = new Vector3 (transform.position.x + (float)MoveSpeed * tm, 0, 120);
		else
			transform.position = new Vector3 (-60, 0, 120);

		AnimationUpdate ();
	}
}
