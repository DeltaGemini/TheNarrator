using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
		public GUISkin inGameGUI;
		public string resultA;
		public string resultB;
		private GUIText description;
		private GUIText choice1;
		private GUIText choice2;
		private GUIText choice3;
		private GUIText choice4;
		private GUITexture choiceWindow1;
		private GUITexture choiceWindow2;
		private GUITexture choiceWindow3;
		private GUITexture choiceWindow4;
		public string highValueSceneName;
		public string lowValueSceneName;
		public int decisionValue;
		public bool gameOverScene = false;
		private int score = 0;
		private List<GUIText> choices;
		private List<GUITexture> choiceWindows;
		public List<EventText> eventTexts;
		private int textPos = -1;
		private bool showedLastText=false;
		// Use this for initialization
		void Start ()
		{
				description = GameObject.FindGameObjectWithTag ("text").GetComponent<GUIText> ();

				choice1 = GameObject.FindGameObjectWithTag ("choice1").GetComponent<GUIText> ();
				choice2 = GameObject.FindGameObjectWithTag ("choice2").GetComponent<GUIText> ();
				choice3 = GameObject.FindGameObjectWithTag ("choice3").GetComponent<GUIText> ();
				choice4 = GameObject.FindGameObjectWithTag ("choice4").GetComponent<GUIText> ();

				choiceWindow1 = GameObject.FindGameObjectWithTag ("choiceOverlay1").GetComponent<GUITexture> ();
				choiceWindow2 = GameObject.FindGameObjectWithTag ("choiceOverlay2").GetComponent<GUITexture> ();
				choiceWindow3 = GameObject.FindGameObjectWithTag ("choiceOverlay3").GetComponent<GUITexture> ();
				choiceWindow4 = GameObject.FindGameObjectWithTag ("choiceOverlay4").GetComponent<GUITexture> ();

				description.text = "";
				choice1.text = "";
				choice2.text = "";
				choice3.text = "";
				choice4.text = "";

				choices = new List<GUIText> ();

				choices.Add (choice1);
				choices.Add (choice2);
				choices.Add (choice3);
				choices.Add (choice4);

				choiceWindows = new List<GUITexture> ();

				choiceWindows.Add (choiceWindow1);
				choiceWindows.Add (choiceWindow2);
				choiceWindows.Add (choiceWindow3);
				choiceWindows.Add (choiceWindow4);

				choiceWindow1.enabled = false;
				choiceWindow2.enabled = false;
				choiceWindow3.enabled = false;
				choiceWindow4.enabled = false;

				UpdateTextsAndChoices ();

		}

		public void selectChoice (int choiceNumber)
		{
				score += eventTexts [textPos].choices [choiceNumber].choiceValue;
				UpdateTextsAndChoices ();
		}

		public void UpdateTextsAndChoices ()
		{
				if (textPos < eventTexts.Count - 1) {
						textPos++;
						description.text = eventTexts [textPos].descriptionText;
			
						if (gotChoices ()) {
								for (int i=0; i<eventTexts[textPos].choices.Count; i++) {
										choices [i].text = eventTexts [textPos].choices [i].choiceText;
										//choiceWindows [i].enabled = true;
								}
						} else {
								choice1.text = "";
								choice2.text = "";
								choice3.text = "";
								choice4.text = "";

								choiceWindow1.enabled = false;
								choiceWindow2.enabled = false;
								choiceWindow3.enabled = false;
								choiceWindow4.enabled = false;
						}
				} else if(!showedLastText){
				Debug.Log ("SHOWING LAST TEXT!");
				showedLastText=true;
				description.text = "";
				choice1.text = "";
				choice2.text = "";
				choice3.text = "";
				choice4.text = "";
				
				choiceWindow1.enabled = false;
				choiceWindow2.enabled = false;
				choiceWindow3.enabled = false;
				choiceWindow4.enabled = false;

				if(score>=decisionValue){
					description.text = resultA;
				} else {
					description.text = resultB;				

				}
		} else {
			AfterLastText();
		}
	}

		public void AfterLastText(){
		description.text = "";
		choice1.text = "";
		choice2.text = "";
		choice3.text = "";
		choice4.text = "";
		
		choiceWindow1.enabled = false;
		choiceWindow2.enabled = false;
		choiceWindow3.enabled = false;
		choiceWindow4.enabled = false;
		
		GameObject.FindGameObjectWithTag ("fadeInOut").GetComponent<FadeInOut> ().Fade (false);
		Invoke ("LoadNewScene", GameObject.FindGameObjectWithTag ("fadeInOut").GetComponent<FadeInOut> ().fadeTime);

		}

		public void LoadNewScene ()
		{
				if (gameOverScene) {
						GameObject.FindGameObjectWithTag ("SceneManager").GetComponent<SceneManager> ().GoBackInTime ();
				} else {
						if (score >= decisionValue) {
								Application.LoadLevel (highValueSceneName);
						} else {
								Application.LoadLevel (lowValueSceneName);
						}
				}			
		}

		private bool gotChoices ()
		{
				return (eventTexts [textPos].choices != null && eventTexts [textPos].choices.Count > 0);
		}

		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (0) && !gotChoices ()) {
						UpdateTextsAndChoices ();
				}
		}

		void OnGUI ()
		{
				GUI.skin = inGameGUI;

				GUI.Label (new Rect (35, 30, 500, 300), description.text);
				
				if(choice1.text!=null && choice1.text!=""){
					if (GUI.Button (new Rect (35, 310, 310, 150), choice1.text)) {					
						GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ().selectChoice (0);
					}
				}

				if(choice2.text!=null && choice2.text!=""){
					if (GUI.Button (new Rect (35, 380, 500, 150), choice2.text)) {					
						GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ().selectChoice (1);
					}
				}

				if(choice3.text!=null && choice3.text!=""){
					if (GUI.Button (new Rect (35, 450, 500, 150), choice3.text)) {					
						GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ().selectChoice (2);
					}
				}

				if(choice4.text!=null && choice4.text!=""){
					if (GUI.Button (new Rect (35, 520, 500, 150), choice4.text)) {					
						GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ().selectChoice (3);
					}
				}
		}
}
	