using UnityEngine;
using System.Collections;

public class current : MonoBehaviour {
	private Vector3 trans;
	private Vector3 startPos;
	private float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range(.02F, .1F);
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		trans = transform.position;
		if(trans.y > 50){
			transform.position = startPos;
		}else{
			trans.x += Random.Range(-.05F, .05F);
			trans.y += speed;
			transform.position = trans;
		}
	}
}
