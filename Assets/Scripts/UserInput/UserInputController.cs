using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Контроллер ввода с клавиатуры
/// </summary>
public class UserInputController
{
	UserInputView _userInputView;
	PlayerMovementModel _playerMovModel;
	Dictionary<KeyCode, ICommand> _commandsDictionary = new Dictionary<KeyCode, ICommand> ();
	ShootModel _shootModel;

	bool _isInputEnable = true;

	public UserInputController (PlayerMovementModel movementModel, ShootModel shotModel)
	{
		_playerMovModel = movementModel;
		_shootModel = shotModel;
		_userInputView = new UserInputView (this);
		GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
		GameManager.Instanse.GameEventSystem.KeyPress += OnKeyPressed;
		GameManager.Instanse.GameEventSystem.KeyUp += OnKeyUp;
		GameManager.Instanse.GameEventSystem.FinishGame += OnFinishGame;

		//инициализируем команды
		_commandsDictionary.Add (KeyCode.UpArrow, new MoveTowardsCommand (_playerMovModel));
		_commandsDictionary.Add (KeyCode.LeftArrow, new RotateLeftCommand (_playerMovModel));
		_commandsDictionary.Add (KeyCode.RightArrow, new RotateRightCommand (_playerMovModel));
		_commandsDictionary.Add (KeyCode.Space, new FireWithWeakWeaponCommand (_shootModel));
		_commandsDictionary.Add (KeyCode.LeftShift, new FireWithStrongBulletCommand ());
		_commandsDictionary.Add(KeyCode.LeftControl, new FireWithStrongLaserCommand());
		_commandsDictionary.Add(KeyCode.Escape, new GamePauseCommand());
	} 

	public UserInputView GetUserInputView()
	{
		return _userInputView;
	}

	public void OnKeyPressed(KeyCode keyCode)
	{
		if (_commandsDictionary.ContainsKey (keyCode) && _isInputEnable) 
		{
			ICommand currentCommand = _commandsDictionary [keyCode];
			if(!GameManager.Instanse.IsGamePaused)//если не пауза
			{
				currentCommand.Execute ();
			}
			else if(keyCode == KeyCode.Escape)//в паузе только Escape
			{
				currentCommand.Execute ();
			}
		}
	}

	public void OnKeyUp(KeyCode keyCode)
	{
		if (keyCode == KeyCode.Space || keyCode == KeyCode.LeftShift || keyCode == KeyCode.LeftControl) {
			_shootModel.SetOnReadyToFire();
		}
	}

	void OnStartGame()
	{
		_isInputEnable = true;
	}

	void OnFinishGame()
	{
		_isInputEnable = false;
	}
}
