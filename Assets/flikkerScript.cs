using UnityEngine;
using System.Collections;

public class flikkerScript : MonoBehaviour {
	
	public bool fadeBlack = true;
	public float fadeSpeed = 5.5f;
	
	// Use this for initialization
	void Start () 
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(fadeBlack)
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
		}
		else
		{
			guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
		
		if(guiTexture.color.a >= 0.95f)fadeBlack = false;	
		if(guiTexture.color.a <= 0.05f)fadeBlack = true;
	}
	
}