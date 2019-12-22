using UnityEngine;

public class BigAsteroidDestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
	}

	public override void CustomDestroyBehavior ()
	{
		health = _initialHealth;
		GameObject shot = PoolManager.GetObject ("BigAsteroidExplosion", transform.position, transform.rotation);
	}

	private void OnDisable() {
		GameManager.Instanse.CurrentAsteroidsCount--;
	}
}
