using UnityEngine;

/// <summary>
/// Модель уничтожения маленького астероида.
/// </summary>
public class SmallAsteroidDestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
	}

	public override void CustomDestroyBehavior ()
	{
		health = _initialHealth;
		GameObject shot = PoolManager.GetObject ("SmallAsteroidExplosion", transform.position, transform.rotation);
	}
}