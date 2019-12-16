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
		_shoter.FireWithWeakWeapon ();
	}
}
