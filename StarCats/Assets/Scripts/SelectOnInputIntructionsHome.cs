﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInputIntructionsHome : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;
	// Use this for initialization
	void Start () {
		eventSystem = EventSystem.current;
		eventSystem.SetSelectedGameObject(null);
		eventSystem.SetSelectedGameObject(selectedObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			//currentbutton = eventSystem.currentSelectedGameObject;
			buttonSelected = true;
		}
		
	}
	
	private void OnEnable()
	{
		eventSystem.SetSelectedGameObject(null);
		eventSystem.SetSelectedGameObject(selectedObject);
	}


	void onDisable()
	{
		buttonSelected = false;
	}
}
