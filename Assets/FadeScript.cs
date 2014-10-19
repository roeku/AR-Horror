using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {
	public bool fade;
	public bool fadeBlack;
	private bool fadeDone;
	public float fadeSpeed = 1.5f;

	// Use this for initialization
	void Start () 
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fade && fadeBlack == false) fadeBlack = true;

		if(fadeBlack)
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
			fade= false;
		}
		else
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
		}

		if(guiTexture.color.a >= 0.95f)fadeBlack = false;

	}
}
