using UnityEngine;
using System.Collections;

public class FailureMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("yes");
		this.gameObject.SetActiveRecursively(false);
		GameController.Instance.failMenu = this;
	}
	public void show(){
		this.gameObject.SetActiveRecursively(true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
