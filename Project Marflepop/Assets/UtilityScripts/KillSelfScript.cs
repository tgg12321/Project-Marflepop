using UnityEngine;
using System.Collections;

public class KillSelfScript : MonoBehaviour {

	public double SecondsUntilDeath=2;
	// Use this for initialization
	void Start () {
		StartCoroutine (WaitRoutine ());

	}
	
	// Update is called once per frame
	IEnumerator WaitRoutine(){
		yield return new WaitForSeconds ((float)SecondsUntilDeath);
		GameObject.Destroy (this.gameObject);
	}
}
