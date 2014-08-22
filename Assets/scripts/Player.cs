using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool facingRight = false;
	protected Animator animator;
	public bool left = false;
	public bool right = false;

	public float pushPower = 20.0F;
	public bool touchingBall = false;
	private bool setBallHeight = false;
	private CharacterController cController;
	private GameObject ball;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		cController = GetComponent<CharacterController>();
	}



	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;



		if(hit.gameObject.name == "Ball"){
			Debug.Log("hit");
			Debug.Log(hit.gameObject.name);
			touchingBall = true;
			ball = hit.gameObject; 
		}


		if (body == null || body.isKinematic)
			return;
		

		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;



	}







	public void throwBall(){
		if(ball != null){
			ball.collider.isTrigger = false;
			ball.rigidbody.useGravity = true;
			ball.rigidbody.isKinematic = false;

			ball.transform.parent = transform.parent;
			setBallHeight = false;

			touchingBall = false;

		
			
			Vector3 bvel = cController.velocity;
			bvel.x = bvel.x * .002f;
			bvel.y = bvel.y * .03f;
			ball.rigidbody.AddForce(bvel);
			ball = null; 
		}
	}

	// Update is called once per frame
	void Update () {



		Vector3 pos = transform.position;
				pos.z = 0;
				transform.position = pos;

	
		Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
	
		if(left){
			moveDirection.x = -1;
		}

		if(right){
			moveDirection.x = 1;
		}





				if (moveDirection.x > 0) {
					facingRight = true;
				} else if(moveDirection.x < 0) {
					facingRight = false;
				}




		if(touchingBall){
			if(ball != null){
				ball.collider.isTrigger = true;
				ball.rigidbody.useGravity = false;
				ball.rigidbody.isKinematic = true;
				ball.transform.parent = transform;
				
				if(!setBallHeight){
					Vector3 bpos = transform.position;
					bpos.y += .15f;
					if(facingRight){
						bpos.x +=.7f;
					}else{
						bpos.x -=.7f;
					}
					ball.transform.position = bpos;
					setBallHeight = true;
				}
			}
		}


				SpriteRenderer test = GetComponent<SpriteRenderer> ();

				Vector3 ls = test.transform.localScale;
				if (facingRight) {
	
						ls.x = 1;
				} else {
						ls.x = -1;
				}
				test.transform.localScale = ls;

				if(animator)
				{
					if(moveDirection.x != 0 || left || right){
						if(animator.GetInteger("animationToPlay") != 1){
							animator.SetInteger("animationToPlay",1);
						}
					}else{
						if(animator.GetInteger("animationToPlay") != 0){
							animator.SetInteger("animationToPlay",0);
						}	
					}
				}

		left = false;
		right = false;
		}



	
}