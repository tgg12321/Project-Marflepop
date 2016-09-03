using UnityEngine;
using System.Collections;

public class ShrinkObjectScript : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3 (-.01f, -0.01f, -0.01f);
	}
}
