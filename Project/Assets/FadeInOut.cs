using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour {

	public float alphaFadeValue=1f;
	public float fadeTime = 5.0f;
	public Texture blackTexture;

	public int fadeInOut = 1;

	// Use this for initialization
	void Start () {
		Fade(true);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		alphaFadeValue += Mathf.Clamp01(Time.deltaTime / fadeTime) * fadeInOut;
		
		GUI.color = new Color(0, 0, 0, alphaFadeValue);
		GUI.DrawTexture( new Rect(0, 0, Screen.width+10, Screen.height+10 ), blackTexture );
	}
	
	public void Fade(bool inOut=true){
		alphaFadeValue=(inOut?1:0);
		fadeInOut*=-1;
	}
}
