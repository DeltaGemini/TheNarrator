using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SC_Manager : MonoBehaviour {
	
	public GUISkin inGameGUI;
	public int optionAmount;
	public List<bool> option = new List<bool>();

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
		for(int i = 0; i < optionAmount; i++){
			option[i] = GUI.Toggle (new Rect (guiX, guiY + (i*heightMult), 60, 15), option[i], "Testing Toggle Button");
		}
		if (GUI.Button (new Rect (0, 60, 150, 20), "Ok"))
			print ("user clicked ok");
	}
}
