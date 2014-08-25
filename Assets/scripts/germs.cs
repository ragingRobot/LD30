using UnityEngine;
using System.Collections;

public class germs : MonoBehaviour {
	ParticleSystem particles;
	SpriteRenderer sprite;
	Vector3 trans;
	cellAnimate target;
	public float speedoffset = .001f;
	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem>();
		sprite = GetComponent<SpriteRenderer>();
		particles.Stop();
		particles.enableEmission = false;

		target = GetClosestEnemy ();

	}

	cellAnimate GetClosestEnemy ()
	{


		cellAnimate[] cells = FindObjectsOfType(typeof(cellAnimate)) as cellAnimate[];



		cellAnimate bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(cellAnimate potentialTarget in cells)
		{
			if(potentialTarget.life > 0){
				Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
				float dSqrToTarget = directionToTarget.sqrMagnitude;
				if(dSqrToTarget < closestDistanceSqr)
				{
					closestDistanceSqr = dSqrToTarget;
					bestTarget = potentialTarget;
				}
			}
		}
	
		return bestTarget;
	}
	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.name == "whiteBloodCell" && sprite.enabled){
			particles.Play();
			particles.enableEmission = true;
			sprite.enabled = false;
			collider.enabled = false;
			GameController.Instance.activeGerms -=1;
		}
		
	}
	// Update is called once per frame
	void Update () {

		if(target){
			if(target.life > 0){
				trans = transform.position;
				trans.x += (target.transform.position.x - trans.x) * speedoffset;
				trans.y += (target.transform.position.y - trans.y) * speedoffset;
				transform.position = trans;
			}else{
				target = GetClosestEnemy ();
			}
		}

		//particles.enableEmission = true;
	}
}
