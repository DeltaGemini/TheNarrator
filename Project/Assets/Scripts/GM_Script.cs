using UnityEngine;
using System.Collections;

public class GM_Script : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//Cheat
		if (Input.GetKeyDown (KeyCode.P)) {
			Application.LoadLevel(Application.loadedLevel +1);
		}
	}

	public void SceneLoad(string l){
		Application.LoadLevel (l);
	}
}
