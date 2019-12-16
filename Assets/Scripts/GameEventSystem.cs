﻿using UnityEngine;

public delegate void UserInputEventHandler(KeyCode keyCode);
public delegate void WeaponEventHandler(GameObject weapon ,GameObject victim);
public delegate void UIPlayerPannelEventHandler(int value);

public class GameEventSystem
{

	public event UserInputEventHandler KeyPress;
	public event UserInputEventHandler KeyUp;

	public event WeaponEventHandler Hit;
	public event WeaponEventHandler DestroyObject;
	public event WeaponEventHandler TryToFireWithStrongWeapon;

	public event UIPlayerPannelEventHandler UpdateStrongBulletValue;

	public event UIPlayerPannelEventHandler UpdateHealthValue;


	public void KeyPressEventLaunch(KeyCode keyCode)
	{
		KeyPress (keyCode);
	}

	public void KeyUpEventLaunch(KeyCode keyCode)
	{
		KeyUp (keyCode);
	}

	public void HitEventLaunch(GameObject weapon, GameObject victim)
	{
		Hit (weapon, victim);
	}

	public void DestroyObjectEventLaunch(GameObject weapon, GameObject victim)
	{
		DestroyObject (weapon, victim);
	}

	public void TryToFireWithStrongWeaponLaunch(GameObject weapon, GameObject victim)
	{
		TryToFireWithStrongWeapon (weapon, victim);
	}

	public void UpdateStrongBulletValueLaunch(int value)
	{
		UpdateStrongBulletValue(value);
	}

	public void UpdateHealthValueLaunch(int value)
	{
		UpdateHealthValue(value);
	}
}
