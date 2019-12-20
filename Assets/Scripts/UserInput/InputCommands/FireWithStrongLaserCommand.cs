using UnityEngine;
using System.Collections;

public class FireWithLaserCommand : ICommand {

	//ShootModel _shootModel;
	GameObject param;

	public FireWithLaserCommand ()
	{
		param = new GameObject ();
	}

	public void Execute()
	{
		param = GameManager.Instanse.strongWeaponPrefab;
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, param);
	}
}
