﻿using UnityEngine;
using System.Collections;

public class SuccessMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.SetActiveRecursively(false);
		GameController.Instance.successMenu = this;
	}
	public void show(){
		this.gameObject.SetActiveRecursively(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}