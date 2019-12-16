using UnityEngine;

public class BigAsteroidDestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
		//DestroyObject += GameManager.Instanse.DamageController.OnDestroy;
	}

	public override void CustomDestroyBehavior ()
	{
		health = _initialHealth;
		GameObject shot = PoolManager.GetObject ("BigAsteroidExplosion", transform.position, transform.rotation);
	}
}
