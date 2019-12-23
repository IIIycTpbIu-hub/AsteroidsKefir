using UnityEngine;

/// <summary>
/// Команда выстрела из лазера
/// </summary>
public class FireWithStrongLaserCommand : ICommand {

	//ShootModel _shootModel;
	GameObject _weapon;

	public FireWithStrongLaserCommand ()
	{
		_weapon = GameManager.Instanse.StrongWeaponLaserPrefab;
	}

	public void Execute()
	{
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, _weapon);
	}
}
