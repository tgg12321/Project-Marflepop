using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour {


	Vector3 lastFramePos;
	Vector3 currFramePos;

	float zoomMax=9f;
	float zoomMin = 1.5f;

	RaycastHit hitInfo;
	public GameObject selectionPrefab;
	GameObject selectionCircleGO;
	GameObject selectedUnitGO;
	float vertExtent, horizExtent, minX, minY, maxX, maxY;

	// Use this for initialization
	void Start(){

	}
	// Update is called once per frame
	void Update () {
		Vector3 currFramePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float cameraSize = Camera.main.orthographicSize;
		// Handle left clicks
		if (Input.GetMouseButtonDown(1)) {
			/*if (!checkOverUIElement()) {
				return;
			}
			*/
			Ray ray= Camera.main.ScreenPointToRay (Input.mousePosition);


			if (Physics.Raycast (ray, out hitInfo)) {
				if (selectionCircleGO != null) {
					GameObject.Destroy (selectionCircleGO);

				}

				if (hitInfo.transform.gameObject.name == "Enemy_Zombie_Prefab") {
					Debug.Log ("Zombie hit!!");

				} else {

			
					GameObject movementSelectionGO = (GameObject)GameObject.Instantiate (selectionPrefab, new Vector3 (hitInfo.point.x, .1f, hitInfo.point.z),	Quaternion.identity);
					movementSelectionGO.transform.Rotate (300, 0, 180);
					selectionCircleGO = movementSelectionGO;
					//Easy movement, should probably be changed at some point
					GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovementManager> ().TargetPosition = (new Vector3 (hitInfo.point.x, .1f, hitInfo.point.z));
				}

			}

		}
		if (Input.GetMouseButtonDown (0)) {
			Ray ray= Camera.main.ScreenPointToRay (Input.mousePosition);
	
			if (Physics.Raycast (ray, out hitInfo)) {
				if (selectedUnitGO != null) {
					selectedUnitGO.GetComponentInChildren<SelectionManager> ().unitUnselected ();
				}
				if (hitInfo.transform.gameObject.GetComponentInChildren<SelectionManager> ()) {
					selectedUnitGO = hitInfo.transform.gameObject;
					selectedUnitGO.GetComponentInChildren<SelectionManager> ().unitSelected ();
				
				}

			}

		}

		//Right click or middle mouse press allows panning
		if (Input.GetMouseButton (2) ) {
			
			Vector3 diff = lastFramePos - currFramePos;
			Camera.main.transform.Translate (diff);

		}

		cameraSize -= Input.GetAxis ("Mouse ScrollWheel");
		if (cameraSize < zoomMax && cameraSize> zoomMin) {
			Camera.main.orthographicSize = cameraSize;
		}
		lastFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}







}
