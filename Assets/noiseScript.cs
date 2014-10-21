using UnityEngine;
using System.Collections;

public class noiseScript : MonoBehaviour {
	public bool fade;
	public bool noiseFade;
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
		if(fade && noiseFade == false) noiseFade = true;
		
		if(noiseFade)
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.white, fadeSpeed * Time.deltaTime);
			fade= false;
		}
		else
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
		}

	}
}
