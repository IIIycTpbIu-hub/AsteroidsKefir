using UnityEngine;

/// <summary>
/// Модель уничтожения НЛО.
/// </summary>
public class UFODestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
	}

	public override void CustomDestroyBehavior ()
	{
		health = _initialHealth;
		GameObject shot = PoolManager.GetObject ("UFOExplosion", transform.position, transform.rotation);
	}

	void OnDisable() {
		GameManager.Instanse.CurrentUFOCount--;
	}
	
	
}