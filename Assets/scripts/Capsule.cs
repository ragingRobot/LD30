using UnityEngine;
using System.Collections;

public class Capsule : MonoBehaviour {

	ParticleSystem particles;
	MeshRenderer sprite;
	Vector3 trans;
	int count = 0;

	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem>();
		sprite = transform.Find("default").gameObject.GetComponent<MeshRenderer>();
		particles.Stop();
		particles.enableEmission = false;

	}



	void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.name == "cell" && sprite.enabled){
			particles.Play();
			particles.enableEmission = true;
			sprite.enabled = false;
			collider.enabled = false;
			GameController.Instance.activeGerms -=1;
			audio.Play();
		}
		
	}

	void reproduce(){

		if(GameController.Instance.activeGerms < 100){

				GameObject capsule;
				capsule = Instantiate(transform, 
				                    transform.position, 
				                    transform.rotation) as GameObject;

				GameController.Instance.activeGerms ++;
				GameController.Instance.maxGerms ++;
		}
	




	}


	// Update is called once per frame
	void Update () {
		count ++;
		if(count == 30 && sprite.enabled){
			reproduce();
			//count = 0;
		}
	}
}
