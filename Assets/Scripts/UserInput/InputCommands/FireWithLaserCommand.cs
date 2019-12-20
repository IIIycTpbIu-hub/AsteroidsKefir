using UnityEngine;
using System.Collections;

public class FireWithStrongLaserCommand : ICommand {

	//ShootModel _shootModel;
	GameObject _weapon;

	public FireWithStrongLaserCommand ()
	{
		_weapon = GameManager.Instanse.strongWeaponLaserPrefab;
	}

	public void Execute()
	{
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, _weapon);
	}
}
