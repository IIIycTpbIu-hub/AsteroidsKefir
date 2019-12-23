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
		float speed = GameManager.Instanse.WeakWeaponSpeed;
		GameObject bulletPrefab = GameManager.Instanse.WeakWeaponPrefab;
		_shoter.Fire (speed, bulletPrefab);
	}
}
