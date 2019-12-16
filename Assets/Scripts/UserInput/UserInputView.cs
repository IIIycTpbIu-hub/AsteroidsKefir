using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

//public delegate void UserInputEventHandler(KeyCode keyCode);

public class UserInputView
{
	//public event UserInputEventHandler KeyPress;
	//public event UserInputEventHandler KeyUp;

	UserInputController _inputController;

	public UserInputView(UserInputController inputController)
	{
		_inputController = inputController;
	}
	
	public void OnKeyPressed(KeyCode keyCode)
	{
		GameManager.Instanse.GameEventSystem.KeyPressEventLaunch (keyCode);
		//KeyPress (keyCode);
	}

	public void OnKeyUp(KeyCode keyCode)
	{
		GameManager.Instanse.GameEventSystem.KeyUpEventLaunch (keyCode);
		//KeyUp (keyCode);
	}

	public void Update()
	{
		//Debug.Log(Input.inputString);
//		if (Input.anyKey) {
//			foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
//			{
//				if (Input.GetKey(keyCode))
//				{
//					OnKeyPressed(keyCode);
//				}
//
//			}
//
//		}
		
		foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKey(keyCode))
			{
				OnKeyPressed(keyCode);
			}
			if (Input.GetKeyUp (keyCode)) 
			{
				OnKeyUp(keyCode);
			}
		}
	}
}
