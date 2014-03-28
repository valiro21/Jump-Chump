using UnityEngine;
using System.Collections;

public class TextAnimation : MonoBehaviour {

	Color InitialColor;

	void OnMouseEnter () {
		InitialColor = renderer.material.color;
		renderer.material.color = Color.green;
	}
	
	void OnMouseExit () {
		renderer.material.color = InitialColor;
	}
}
