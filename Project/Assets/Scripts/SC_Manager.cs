using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SC_Manager : MonoBehaviour {
	
	public GUISkin inGameGUI;
	public int optionAmount;
	public bool option01;

	int guiX = 10;
	int guiY = 300;
	int heightMult = 30;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin = inGameGUI;
		/*
		for(int i = 0; i < optionAmount; i++){
			if(GUI.Button (new Rect (guiX, guiY + (i*heightMult), 60, 15), "Testing Toggle Button")){
				print ("User clicked button "+i);
			}
		}
		*/
		if(GUI.Button (new Rect (50, 50, 350, 50), "Testing button text")){
			Debug.Log ("User clicked button");
		}
	}
}
