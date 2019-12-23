using UnityEngine;
using System;

/// <summary>
/// Слушает пользовательский ввод с клавиатуры, передает клавиши контроллеру ввода
/// </summary>
public class UserInputView
{
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
	}

	public void ListenToKeysInput()
	{		
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
