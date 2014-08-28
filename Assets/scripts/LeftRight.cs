using UnityEngine;
using System.Collections;

public class LeftRight : MonoBehaviour {
	int dir = 1;
	public float speed = .02f;
	public bool upDown = false;
	public bool leftRight = true;
	public bool roationObject;
	public GameObject lockToObject;


	Vector3 pos;
	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter(Collision collision) {
		dir = -dir;
	}

	// Update is called once per frame
	void Update () {
		pos = transform.position;
		if(leftRight){
			pos.x += speed * dir;
		}

		if(upDown){
			pos.y += speed * dir;
		}

		if(roationObject){

			transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);
		}


		if(lockToObject){
			transform.position  = lockToObject.transform.position;
		}else{
			transform.position = pos;
		}

	}
}
