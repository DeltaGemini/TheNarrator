using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EventText {
	
	public string descriptionText;
	public List<Choice> choices;
	public float timeUntilNextText=0f;

}