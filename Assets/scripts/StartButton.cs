using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameController.Instance){
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnMouseUp (){
		GameController.Instance.currentLevel = 0;
		Application.LoadLevel("level1");
	}
}
