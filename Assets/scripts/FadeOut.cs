using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	private bool fade = false;
	private Color col;
	// Use this for initialization
	void Start () {
		StartCoroutine(startFade(2));
	}
	
	// Update is called once per frame
	void Update () {
		if(fade){
			col = renderer.material.color;
			col.a -=.01f;

			renderer.material.color = col;
		}
	}

	IEnumerator startFade(float delay) {
		yield return new WaitForSeconds(delay);
		fade = true;
		
	}
}
