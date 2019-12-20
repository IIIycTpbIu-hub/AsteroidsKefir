using UnityEngine;
using System.Collections;

public class FireWithStrongWeaponCommand : ICommand {

	//ShootModel _shootModel;
	GameObject param;

	public FireWithStrongWeaponCommand ()
	{
		param = new GameObject ();
	}

	public void Execute()
	{
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, param);
	}
}
