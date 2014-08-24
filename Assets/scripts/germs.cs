using UnityEngine;
using System.Collections;

public class germs : MonoBehaviour {
	ParticleSystem particles;
	SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem>();
		sprite = GetComponent<SpriteRenderer>();
		particles.Stop();
		particles.enableEmission = false;
	}


	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.name == "whiteBloodCell" && sprite.enabled){
			particles.Play();
			particles.enableEmission = true;
			sprite.enabled = false;
			collider.enabled = false;
		}
		
	}
	// Update is called once per frame
	void Update () {



		//particles.enableEmission = true;
	}
}
