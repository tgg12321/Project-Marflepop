using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementManager : MonoBehaviour {
	
	public float speed=1f;
	public Vector3 TargetPosition=new Vector3(0, .1f,0);
	private float step;
	Dictionary<string, Sprite>spriteDictionary=new Dictionary<string, Sprite>();

	void Start(){
		step = speed * Time.deltaTime;
		Sprite[] sprites = Resources.LoadAll<Sprite>("SpriteSheets");
		foreach (Sprite spr in sprites) {
			spriteDictionary.Add (spr.name, spr);
		}


	}
	void Update(){
		updateSprite (TargetPosition);
		moveTowards (TargetPosition);
	}
	public void moveTowards(Vector3 position){
		if(transform.position!=position){
			transform.position = Vector3.MoveTowards (transform.position, position, step);
		}
	}

	public void updateSprite(Vector3 pos){
		Sprite spr = GetComponent<SpriteRenderer> ().sprite;
		if (pos != transform.position) {
			switch ((int)(vectorToCardinal (pos))) {
			case 0:
				spriteDictionary.TryGetValue ("clothes_0_S", out spr);
				break;
			case 1:
				spriteDictionary.TryGetValue ("clothes_0_SW", out spr);
				break;
			case 2:
				spriteDictionary.TryGetValue ("clothes_0_W", out spr);
				break;
			case 3:
				spriteDictionary.TryGetValue ("clothes_0_NW", out spr);
				break;
			case 4:
				spriteDictionary.TryGetValue ("clothes_0_N", out spr);
				break;
			case 5:
				spriteDictionary.TryGetValue ("clothes_0_NE", out spr);
				break;
			case 6:
				spriteDictionary.TryGetValue ("clothes_0_E", out spr);
				break;
			case 7:
				spriteDictionary.TryGetValue ("clothes_0_SE", out spr);
				break;
			}

			this.gameObject.GetComponent<SpriteRenderer> ().sprite = spr;
		}

	}

	private float vectorToCardinal(Vector3 pos){
		Vector3 vector = transform.position - pos;
		float angle = Mathf.Atan2 (vector.x, vector.z);
		return Mathf.Round(8 * angle / (2 * Mathf.PI) + 8) % 8;
	
	}
}
