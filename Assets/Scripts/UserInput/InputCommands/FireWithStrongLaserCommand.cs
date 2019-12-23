using UnityEngine;

/// <summary>
/// Команда выстрела из лазера
/// </summary>
public class FireWithLaserCommand : ICommand {

	GameObject _nullParam;

	public FireWithLaserCommand ()
	{
		_nullParam = new GameObject ();
	}

	public void Execute()
	{
		_nullParam = GameManager.Instanse.StrongWeaponPrefab;
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeaponLaunch (0, _nullParam);
	}
}
