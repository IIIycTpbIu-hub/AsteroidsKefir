using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInputController
{
	UserInputView _userInputView;
	PlayerMovementModel _playerMovModel;
	Dictionary<KeyCode, ICommand> _commands = new Dictionary<KeyCode, ICommand> ();
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
		_commands.Add (KeyCode.W, new MoveTowardsCommand (_playerMovModel));
		_commands.Add (KeyCode.A, new RotateLeftCommand (_playerMovModel));
		_commands.Add (KeyCode.D, new RotateRightCommand (_playerMovModel));
		_commands.Add (KeyCode.Space, new FireWithWeakWeaponCommand (_shootModel));
		_commands.Add (KeyCode.Mouse0, new FireWithStrongBulletCommand ());
		_commands.Add(KeyCode.Mouse1, new FireWithStrongLaserCommand());
		_commands.Add(KeyCode.Escape, new GamePauseCommand());
	} 

	public void OnKeyPressed(KeyCode keyCode)
	{
		if (_commands.ContainsKey (keyCode) && _isInputEnable) 
		{
			ICommand currentCommand = _commands [keyCode];
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
		if (keyCode == KeyCode.Space || keyCode == KeyCode.Mouse0 || keyCode == KeyCode.Mouse1) {
			_shootModel.SetOnReadyToFire();
		}
	}

	public UserInputView GetUserInputView()
	{
		return _userInputView;
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
