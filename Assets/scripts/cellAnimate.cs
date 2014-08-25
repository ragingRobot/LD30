using UnityEngine;
using System.Collections;

public class cellAnimate : MonoBehaviour {
	protected Animator animator;
	private ParticleSystem particles;
	public int life = 4;
	GameObject body;
	// Use this for initialization
	void Start () {
		body = transform.Find("body").gameObject;
		animator = body.GetComponent<Animator>();
		particles = GetComponent<ParticleSystem>();
		particles.Stop();
		particles.enableEmission = false;

	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name == "germ" && body.renderer.enabled){


				if(life > 1){
					life -= 1;
					animator.SetInteger("life",life);
				}else{
					life =0;
					particles.Play();
					particles.enableEmission = true;
					body.renderer.enabled = false;
					GameController.Instance.activeBloodCells -=1;
					body.collider.enabled = false;
					this.collider.enabled = false;
					AutoDestruct(1);
				}


		}


		if(collision.gameObject.name == "crust" && body.renderer.enabled){
			
			
			if(life > 1){
				life -= 1;
				animator.SetInteger("life",life);
			}else{
				life =0;
				particles.Play();
				particles.enableEmission = true;
				body.renderer.enabled = false;
				GameController.Instance.activeBloodCells -=1;
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
