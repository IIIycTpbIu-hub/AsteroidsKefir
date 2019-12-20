using UnityEngine;
using System.Collections;

public class FireWithStrongBulletCommand : ICommand {

	//ShootModel _shootModel;
	GameObject _weapon;

	public FireWithStrongBulletCommand ()
	{
		_weapon = GameManager.Instanse.strongWeaponPrefab;;
	}

	public void Execute()
	{
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, _weapon);
	}
}
