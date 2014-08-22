using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent (typeof (CharacterMotorC))]
//RequireComponent (CharacterMotor)
[AddComponentMenu("Character/FPS Input Controller C")]
//@script AddComponentMenu ("Character/FPS Input Controller")


public class FPSInputControllerC : MonoBehaviour
{
	
	public CharacterMotorC cmotor;
	public GUITexture leftTexture;
	public GUITexture rightTexture;
	public GUITexture jumpTexture;
	public GUITexture throwTexture;

	private Player playerController;
	private Vector3 directionVector;
	private bool left = false;
	private bool right = false;
	private bool jump = false;
	private bool throwIt = false;
	private Rect leftRect;
	private Rect rightRect;
	private Rect jumpRect;

	// Use this for initialization
	void Awake ()
	{
		cmotor = GetComponent<CharacterMotorC>();
		playerController = GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		if(playerController.touchingBall){
			throwTexture.enabled  = true;
		}else{
			throwTexture.enabled  = false;
		}

		if(Input.touchCount > 0) {
			for (int i = 0; i<Input.touchCount; i++) {

					Touch touch = Input.GetTouch(i);

					if(leftTexture.HitTest(touch.position)){
						left = true;
						playerController.left = true;
					}

					if(rightTexture.HitTest(touch.position)){
						right = true;
						playerController.right = true;
					}


					if(jumpTexture.HitTest(touch.position)){
						jump = true;
					}

					if(throwTexture.HitTest(touch.position)){
						throwIt = true;
					}
			
			}
		}
	
		if(Input.mousePosition != null) {

				
			if(throwTexture.HitTest(Input.mousePosition)){
					throwIt = true;
			}
				
		
		}


		if(left){
			directionVector = cmotor.inputMoveDirection;
			directionVector.x = -1;
			cmotor.inputMoveDirection = directionVector;
			
		}else if(right){
			directionVector = cmotor.inputMoveDirection;
			directionVector.x = 1;
			cmotor.inputMoveDirection = directionVector;
			
		} else{
			directionVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		

			if (directionVector != Vector3.zero)
			{
				// Get the length of the directon vector and then normalize it
				// Dividing by the length is cheaper than normalizing when we already have the length anyway
				float directionLength = directionVector.magnitude;
				directionVector = directionVector / directionLength;
				
				// Make sure the length is no bigger than 1
				directionLength = Mathf.Min(1, directionLength);
				
				// Make the input vector more sensitive towards the extremes and less sensitive in the middle
				// This makes it easier to control slow speeds when using analog sticks
				directionLength = directionLength * directionLength;
				
				// Multiply the normalized direction vector by the modified length
				directionVector = directionVector * directionLength;
			}

		

		
			// Apply the direction to the CharacterMotor
			cmotor.inputMoveDirection = transform.rotation * directionVector;

		}

		if(jump){
			cmotor.inputJump = true;
		}else{
			cmotor.inputJump = Input.GetButton("Jump");
		}



		if(throwIt){
			playerController.throwBall();
		}

		left = false;
		right = false;
		jump = false;
		throwIt = false;

	}


	
}