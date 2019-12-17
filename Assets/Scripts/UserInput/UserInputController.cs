using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInputController
{
	UserInputView _userInputView;
	PlayerMovementModel _playerMovModel;
	Dictionary<KeyCode, ICommand> _commands = new Dictionary<KeyCode, ICommand> ();
	ShootModel _shootModel;

	public UserInputController (PlayerMovementModel movementModel, ShootModel shotModel)
	{
		_playerMovModel = movementModel;
		_shootModel = shotModel;
		_userInputView = new UserInputView (this);
		//_userInputView.KeyPress += OnKeyPressed;
		//_userInputView.KeyUp += OnKeyUp;
		GameManager.Instanse.GameEventSystem.KeyPress += OnKeyPressed;
		GameManager.Instanse.GameEventSystem.KeyUp += OnKeyUp;

		//инициализируем команды
		_commands.Add (KeyCode.W, new MoveTowardsCommand (_playerMovModel));
		_commands.Add (KeyCode.A, new RotateLeftCommand (_playerMovModel));
		_commands.Add (KeyCode.D, new RotateRightCommand (_playerMovModel));
		_commands.Add (KeyCode.Space, new FireWithWeakWeaponCommand (_shootModel));
		_commands.Add (KeyCode.R, new FireWithStrongWeaponCommand ());
		_commands.Add(KeyCode.Escape, new GamePauseCommand());
	} 

	public void OnKeyPressed(KeyCode keyCode)
	{
		if (_commands.ContainsKey (keyCode)) {
			ICommand currentCommand = _commands [keyCode];
			currentCommand.Execute ();
		}
	}

	public void OnKeyUp(KeyCode keyCode)
	{
		if (keyCode == KeyCode.Space || keyCode == KeyCode.R) {
			_shootModel.SetOnReadyToFire();
		}
	}

	public UserInputView GetUserInputView()
	{
		return _userInputView;
	}
}
