﻿using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnMouseUp (){
		Application.LoadLevel(Application.loadedLevel);
	}
}
