using UnityEngine;

public class UFODestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
	}

	void OnDisable() {
		GameManager.Instanse.CurrentUFOCount--;
	}
	
	public override void CustomDestroyBehavior ()
	{
		health = _initialHealth;
		GameObject shot = PoolManager.GetObject ("UFOExplosion", transform.position, transform.rotation);
	}
}