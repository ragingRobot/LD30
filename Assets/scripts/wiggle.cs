using UnityEngine;
using System.Collections;

public class wiggle : MonoBehaviour {
	private Vector3 trans;
	public bool stop = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(!stop){
			trans = transform.position;
			trans.x += Random.Range(-.05F, .05F);
			trans.y += Random.Range(-.05F, .05F);
			trans.z =0;
			transform.position = trans;
		}
	}
}
