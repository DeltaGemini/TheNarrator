using UnityEngine;
using System.Collections;

public class GM_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Cheat
		if (Input.GetMouseButton(0)) {
			Application.LoadLevel("16");
		}
	}

	public void SceneLoad(string l){
		Application.LoadLevel (l);
	}
}
