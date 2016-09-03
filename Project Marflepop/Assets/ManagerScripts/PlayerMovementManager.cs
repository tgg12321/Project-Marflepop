using UnityEngine;
using System.Collections;

public class PlayerMovementManager : MonoBehaviour {

	public float speed=1f;
	public Vector3 TargetPosition=new Vector3(0, .1f,0);
	private float step;
	void Start(){
		step = speed * Time.deltaTime;

	}
	void Update(){
		moveTowards (TargetPosition);
	}
	public void moveTowards(Vector3 position){
		if(transform.position!=position){
			transform.position = Vector3.MoveTowards (transform.position, position, step);
		}
	}
}
