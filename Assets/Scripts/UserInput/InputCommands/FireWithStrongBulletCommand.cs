using UnityEngine;

/// <summary>
/// Команда выстрела из тяжелого оружия
/// </summary>
public class FireWithStrongBulletCommand : ICommand {

	GameObject _weapon;

	public FireWithStrongBulletCommand ()
	{
		_weapon = GameManager.Instanse.StrongWeaponPrefab;;
	}

	public void Execute()
	{
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, _weapon);
	}
}
