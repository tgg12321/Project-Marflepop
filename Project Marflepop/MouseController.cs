using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour {


	Vector3 lastFramePos;
	Vector3 currFramePos;

	public GameObject selectionPrefab;
	GameObject selection;
	float zoomMax=9f;
	float zoomMin = 1.5f;

	RaycastHit hitInfo;
	public GameObject ourHitObject;

	float vertExtent, horizExtent, minX, minY, maxX, maxY;

	// Use this for initialization
	void Start(){

	}
	// Update is called once per frame
	void Update () {
		Vector3 currFramePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float cameraSize = Camera.main.orthographicSize;
		// Handle left clicks
		if (Input.GetMouseButtonDown (0)) {
			if (!checkOverUIElement()) {
				return;
			}
			Ray ray= Camera.main.ScreenPointToRay (Input.mousePosition);


			if (Physics.Raycast (ray, out hitInfo)) {
					
					if (selection != null)//If a selection already exists
						Destroy (selection);
			
				//Set the selected object for world controller, and instantiate the SelectionPrefab behind the object
				ourHitObject = hitInfo.collider.transform.gameObject;
				selection= (GameObject)Instantiate (selectionPrefab, new Vector3 (ourHitObject.GetComponent<HexReference>().HexRef.UnityXCoord, ourHitObject.GetComponent<HexReference>().HexRef.UnityYCoord, 0), Quaternion.identity);
				GetComponentInParent<WorldController> ().updateSelectedObject (ourHitObject);


			}
		}


		//Right click or middle mouse press allows panning
		if (Input.GetMouseButton (1) || Input.GetMouseButton (2)) {
			if (!checkOverUIElement()) {
				return;
			}
			Vector3 diff = lastFramePos - currFramePos;
			Camera.main.transform.Translate (diff);

		}

		cameraSize += Input.GetAxis ("Mouse ScrollWheel");
		if (cameraSize < zoomMax && cameraSize> zoomMin) {
			Camera.main.orthographicSize = cameraSize;
		}
		lastFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}

	public bool checkOverUIElement(){
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return false;
		} else {
			return true;
		}


	}





}
