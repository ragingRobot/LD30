using UnityEngine;
using System.Collections;

public class WhiteBloodCell : MonoBehaviour {
	private ParticleSystem particles;
	GameObject body;
	public int life = 1;
	// Use this for initialization
	void Start () {
		body = transform.Find("Cylinder").gameObject;


		particles = GetComponent<ParticleSystem>();
		particles.Stop();
		particles.enableEmission = false;
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "crust" && body.renderer.enabled){
			
			
			if(life > 1){
				life -= 1;
			}else{
				life =0;
				particles.Play();
				particles.enableEmission = true;
				body.renderer.enabled = false;
				GameController.Instance.activeWhiteCells -=1;
				body.collider.enabled = false;
				this.collider.enabled = false;
				AutoDestruct(1);
			}
			
			
		}
	}
	IEnumerator AutoDestruct(float delay) {
		yield return new WaitForSeconds(delay);
		DestroyObject(this);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
