﻿using UnityEngine;
using System.Collections;

public class Edmond : MonoBehaviour {
	protected Animator animator;
	bool dead = false;
	bool gameEnded = false;
	bool loadingNext = false;

	// Use this for initialization
	void Start () {

		cellAnimate[] cells = FindObjectsOfType(typeof(cellAnimate)) as cellAnimate[];
		WhiteBloodCell[] whiteCells = FindObjectsOfType(typeof(WhiteBloodCell)) as WhiteBloodCell[];
		germs[] germList = FindObjectsOfType(typeof(germs)) as germs[];
		Capsule[] capsuleList = FindObjectsOfType(typeof(Capsule)) as Capsule[];

		GameController.Instance.activeBloodCells = cells.Length;
		GameController.Instance.maxBloodCells = cells.Length;

		GameController.Instance.activeWhiteCells = whiteCells.Length;
		GameController.Instance.maxWhiteCells = whiteCells.Length;

		GameController.Instance.activeGerms = germList.Length + capsuleList.Length;
		GameController.Instance.maxGerms = germList.Length + capsuleList.Length;


		animator = GetComponent<Animator>();
	}
	void death(){
		if(!dead && !gameEnded){

			if(GameController.Instance.failMenu){
				GameController.Instance.failMenu.show();
			}

			gameEnded = true;
			dead = true;
			animator.SetInteger("sicknessLevel",4);
			audio.Play();

		
			//StartCoroutine(reloadLevel(3));

		}
	}


	void nextLevel(){
		if(!loadingNext && !gameEnded){

			if(GameController.Instance.successMenu){
				GameController.Instance.successMenu.show();
			}
			gameEnded = true;
			loadingNext = true;
			//StartCoroutine(loadNextLevel(1));
		}

	}


	// Update is called once per frame
	void Update () {
		if(animator && !dead)
		{
		
			if(GameController.Instance.maxBloodCells > 0){
				if(GameController.Instance.activeBloodCells > 0){
						float val = (float)GameController.Instance.activeBloodCells / (float)GameController.Instance.maxBloodCells;
						
						if(val < .4f){
							animator.SetInteger("sicknessLevel",3);
						}else if(val < .7f){
							animator.SetInteger("sicknessLevel",2);
						}else{
							animator.SetInteger("sicknessLevel",1);
						}
				}else{
					death();

				}
			} else {
		
				if(GameController.Instance.activeWhiteCells > 0){
					float val = (float)GameController.Instance.activeWhiteCells / (float)GameController.Instance.maxWhiteCells;
					
					if(val < .4f){
						animator.SetInteger("sicknessLevel",3);
					}else if(val < .7f){
						animator.SetInteger("sicknessLevel",2);
					}else{
						animator.SetInteger("sicknessLevel",1);
					}
				}else{
					death();
					
				}
			}




			if(GameController.Instance.activeGerms == 0){
				nextLevel();
			}else if(GameController.Instance.activeGerms > 90){
				animator.SetInteger("sicknessLevel",4);
				death();
			}else if(GameController.Instance.activeGerms > 60){
				if(animator.GetInteger("sicknessLevel")< 3){
					animator.SetInteger("sicknessLevel",3);
				}
			}else if(GameController.Instance.activeGerms > 30){
				if(animator.GetInteger("sicknessLevel")< 2){
					animator.SetInteger("sicknessLevel",2);
				}
			}


		}
	}
}
