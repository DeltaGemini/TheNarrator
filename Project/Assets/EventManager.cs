using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	public GameObject mainCharacter;
	public GameObject secondaryCharacter;

	private GUIText description;

	private GUIText choice1;
	private GUIText choice2;
	private GUIText choice3;
	private GUIText choice4;

	private int score=0;

	private List<GUIText> choices;

	public List<EventText> eventTexts;

	private int textPos =0;
	// Use this for initialization
	void Start () {
		description = GameObject.FindGameObjectWithTag("text").GetComponent<GUIText>();
		choice1 = GameObject.FindGameObjectWithTag("choice1").GetComponent<GUIText>();
		choice2 = GameObject.FindGameObjectWithTag("choice2").GetComponent<GUIText>();
		choice3 = GameObject.FindGameObjectWithTag("choice3").GetComponent<GUIText>();
		choice4 = GameObject.FindGameObjectWithTag("choice4").GetComponent<GUIText>();

		description.text=eventTexts[textPos].descriptionText;
		choice1.text="";
		choice2.text="";
		choice3.text="";
		choice4.text="";

		choices = new List<GUIText>();

		choices.Add(choice1);
		choices.Add(choice2);
		choices.Add(choice3);
		choices.Add(choice4);

	}

	public void selectChoice(int choiceNumber){
		score+=eventTexts[textPos].choices[choiceNumber].choiceValue;
		UpdateTextsAndChoices();
	}

	public void UpdateTextsAndChoices(){
		if(textPos<eventTexts.Count-1){
			textPos++;
			description.text=eventTexts[textPos].descriptionText;
			
			if(gotChoices()){
				for(int i=0;i<eventTexts[textPos].choices.Count;i++){
					choices[i].text=eventTexts[textPos].choices[i].choiceText;
				}
			} else {
				choice1.text="";
				choice2.text="";
				choice3.text="";
				choice4.text="";
			}
		} else {
			Debug.Log ("FINISH!");

			description.text="";
			choice1.text="";
			choice2.text="";
			choice3.text="";
			choice4.text="";
		}
	}

	private bool gotChoices(){
		return (eventTexts[textPos].choices!=null && eventTexts[textPos].choices.Count>0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && !gotChoices()){
			UpdateTextsAndChoices();
		}
	}

	void OnGUI(){
	}
}
