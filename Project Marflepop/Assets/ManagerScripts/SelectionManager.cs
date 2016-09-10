using UnityEngine;
using System.Collections;

public class SelectionManager : MonoBehaviour {


	public void unitSelected(){
		GetComponent<SpriteRenderer> ().enabled=true;

	}

	public void unitUnselected(){
		GetComponent<SpriteRenderer> ().enabled=false;
	}


}
