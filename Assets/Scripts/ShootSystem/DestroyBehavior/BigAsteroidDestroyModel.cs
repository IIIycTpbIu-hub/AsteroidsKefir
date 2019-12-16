using UnityEngine;
using System.Collections;

public class BigAsteroidDestroyModel : BaseCustomDestoroyModel {

	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
		//DestroyObject += GameManager.Instanse.DamageController.OnDestroy;
	}

	public override void Destroy ()
	{
		health = _initialHealth;
		gameObject.GetComponent<PoolObject> ().ReturnToPool ();
		//DestroyObject (gameObject, gameObject);
	}
}
