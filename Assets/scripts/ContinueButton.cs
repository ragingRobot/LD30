using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnMouseUp (){
		if(GameController.Instance.currentLevel < GameController.Instance.levels.Length -1){
			GameController.Instance.currentLevel +=1;
			Application.LoadLevel(GameController.Instance.levels[GameController.Instance.currentLevel]);
		}
	}
}
