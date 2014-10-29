using UnityEngine;
using System.Collections;

public class fadeInAlpha : MonoBehaviour {
	public Material fadeTexture;
	private Color fadeColor;
	private Color startColor;
	private Color endColor;
	// Use this for initialization
	void OnEnable () {
		Debug.Log("ik start jong");
		startColor = Color.black;
		startColor.a = 0.0f;
		endColor = Color.black;
		endColor.a = 1.0f;
		fadeColor = startColor;
		fadeTexture.SetColor("_Color", fadeColor);
	}
	
	// Update is called once per frame
	void Update () {

		fadeColor = Color.Lerp(fadeColor, endColor, 1.5f * Time.deltaTime);
		fadeTexture.SetColor("_Color", fadeColor);
	}
}