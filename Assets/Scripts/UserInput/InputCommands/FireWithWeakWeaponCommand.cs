using UnityEngine;
using System.Collections;

public class FireWithWeakWeaponCommand : ICommand {

	ShootModel _shoter;

	public FireWithWeakWeaponCommand(ShootModel shoter)
	{
		_shoter = shoter;
	}
	
	public void Execute()
	{
		float speed = GameManager.Instanse.weakWeaponSpeed;
		GameObject bulletPrefab = GameManager.Instanse.weakWeaponPrefab;
		_shoter.Fire (speed, bulletPrefab);
	}
}
