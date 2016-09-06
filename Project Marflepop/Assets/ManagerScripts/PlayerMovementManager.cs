using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementManager : MonoBehaviour {
	
	public float speed=1f;
	public Vector3 TargetPosition=new Vector3(0, .1f,0);
	private Animator animator;
	private float step;
	public direction currDirection=direction.N;
	PlayerState currState=PlayerState.IDLE;

	Dictionary<string, Sprite>spriteDictionary=new Dictionary<string, Sprite>();

	public enum direction{
		S=0, SW=1, 
		W=2, NW=3, 
		N=4, NE=5,
		E=6, SE=7

	};


	void Start(){
		animator = GetComponent<Animator> ();
		step = speed * Time.deltaTime;
	

	}
	void Update(){
		updateSprite (TargetPosition);
		moveTowards (TargetPosition);
		runPlayerAnimation (currDirection, currState);
	}
	public void moveTowards(Vector3 position){
		if (transform.position != position) {
			transform.position = Vector3.MoveTowards (transform.position, position, step);
			currState = PlayerState.RUNNING;
		} else {
			
			currState = PlayerState.IDLE;
			animator.SetBool ("Running" , false);
		}
	}

	public void updateSprite(Vector3 pos){

		if (pos != transform.position) {
			currDirection = (direction)(vectorToCardinal (pos));
		}

		

	}

	private float vectorToCardinal(Vector3 pos){
		Vector3 vector = transform.position - pos;
		float angle = Mathf.Atan2 (vector.x, vector.z);
		return Mathf.Round(8 * angle / (2 * Mathf.PI) + 8) % 8;
	
	}


	public void runPlayerAnimation(direction dir, PlayerState state){
		
		if (state == PlayerState.RUNNING) {
			animator.SetBool ("Running", true);
			animator.SetFloat("FloatDirection", (float)dir);
		}

	}

}
