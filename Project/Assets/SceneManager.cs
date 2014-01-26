using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

	private static bool created = false;
	
	void Awake() {
		if (!created) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(this.gameObject);
			created = true;
		} else {
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		} 
	}
	
	private List<string> scenes;
	public int pos=-1;

	// Use this for initialization
	void Start () {	
		scenes = new List<string>();
		scenes.Add("11");
		scenes.Add("7");
		scenes.Add("5");
		scenes.Add("3");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoBackInTime(){
		pos++;
		Application.LoadLevel(scenes[pos]);
	}

}
