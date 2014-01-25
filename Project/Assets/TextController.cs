using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {

	public int choice=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log ("Choice: "+(choice+1));
		GameObject.FindGameObjectWithTag("EventManager").GetComponent<EventManager>().selectChoice(choice);
	}
}
