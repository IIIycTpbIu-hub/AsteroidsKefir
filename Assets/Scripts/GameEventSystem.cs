using UnityEngine;

public delegate void UserInputEventHandler(KeyCode keyCode);
public delegate void WeaponEventHandler(int damage, GameObject victim);
public delegate void UIPlayerPannelEventHandler(int value);
public delegate void DisplayModeEventHandled(bool value);
public delegate void AwaitEventHandler(float seconds);
public delegate void GameStateHandler();
public class GameEventSystem
{

	public event UserInputEventHandler KeyPress;
	public event UserInputEventHandler KeyUp;

	public event WeaponEventHandler Hit;
	public event WeaponEventHandler DestroyObject;
	public event WeaponEventHandler TryToFireWithStrongWeapon;

	public event UIPlayerPannelEventHandler UpdateStrongBulletValue;
	public event UIPlayerPannelEventHandler UpdateHealthValue;
	public event DisplayModeEventHandled SwitchDisplayMode;
	public event AwaitEventHandler AwaitForAwhile;
	public event AwaitEventHandler AwaitComplit;
	public event GameStateHandler StartGame;
	public event GameStateHandler PauseGame;
	public event GameStateHandler FinishGame; 

	public void KeyPressEventLaunch(KeyCode keyCode)
	{
		KeyPress (keyCode);
	}

	public void KeyUpEventLaunch(KeyCode keyCode)
	{
		KeyUp (keyCode);
	}

	public void HitEventLaunch(int damage, GameObject victim)
	{
		Hit (damage, victim);
	}

	public void DestroyObjectEventLaunch(int damage, GameObject victim)
	{
		DestroyObject (damage, victim);
	}

	public void TryToFireWithStrongWeaponLaunch(int damage, GameObject weapon)
	{
		TryToFireWithStrongWeapon (damage, weapon);
	}

	public void UpdateStrongBulletValueLaunch(int value)
	{
		UpdateStrongBulletValue(value);
	}

	public void UpdateHealthValueLaunch(int value)
	{
		UpdateHealthValue(value);
	}

	public void SwitchDisplayModeLaunch(bool isSpriteMode)
	{
		SwitchDisplayMode(isSpriteMode);
	}

	public void AwaitForAwhileLaunch(float seconds)
	{
		AwaitForAwhile(seconds);
	}

	public void AwaitComplitLaunch(float seconds)
	{
		AwaitComplit(seconds);
	}

	public void StartGameLaunch()
	{
		StartGame();
	}

	public void PauseGameLaunch()
	{
		PauseGame();
	}

	public void FinishGameLaunch()
	{
		FinishGame();
	}
}
