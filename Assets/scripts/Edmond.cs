using UnityEngine;
using System.Collections;

public class Edmond : MonoBehaviour {
	protected Animator animator;
	bool dead = false;
	// Use this for initialization
	void Start () {

		cellAnimate[] cells = FindObjectsOfType(typeof(cellAnimate)) as cellAnimate[];

		GameController.Instance.activeBloodCells = cells.Length;
		GameController.Instance.maxBloodCells = cells.Length;
		animator = GetComponent<Animator>();
	}
	void death(){
		if(!dead){
			dead = true;
			animator.SetInteger("sicknessLevel",4);

			StartCoroutine(reloadLevel(3));

		}
	}

	IEnumerator reloadLevel(float delay) {
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(Application.loadedLevel);

	}
	// Update is called once per frame
	void Update () {
		if(animator)
		{
		
			if(GameController.Instance.activeBloodCells > 0){
					float val = (float)GameController.Instance.activeBloodCells / (float)GameController.Instance.maxBloodCells;
					
					if(val < .3f){
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
	}
}
