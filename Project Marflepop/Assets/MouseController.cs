﻿using UnityEngine;
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
	GameObject selectionOb;
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
			/*if (!checkOverUIElement()) {
				return;
			}
			*/
			Ray ray= Camera.main.ScreenPointToRay (Input.mousePosition);


			if (Physics.Raycast (ray, out hitInfo)) {
				//Where the click is located
				if (selectionOb != null) {
					GameObject.Destroy (selectionOb);

				}
				GameObject movementSelectionGO =(GameObject)GameObject.Instantiate(selectionPrefab, new Vector3(hitInfo.point.x, .1f, hitInfo.point.z),	Quaternion.identity);
				movementSelectionGO.transform.Rotate (270, 0, 180);
				selectionOb = movementSelectionGO;
			}
		}


		//Right click or middle mouse press allows panning
		if (Input.GetMouseButton (1) || Input.GetMouseButton (2)) {
			
			Vector3 diff = lastFramePos - currFramePos;
			Camera.main.transform.Translate (diff);

		}

		cameraSize += Input.GetAxis ("Mouse ScrollWheel");
		if (cameraSize < zoomMax && cameraSize> zoomMin) {
			Camera.main.orthographicSize = cameraSize;
		}
		lastFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	}







}
