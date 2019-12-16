using UnityEngine;
using System.Collections;

public class SimpleDestroyModel : MonoBehaviour ,IDestroyable {

	public int health;
	int _initialHealth;
	//public WeaponEventHandler DestroyObject;

	public void TakeDamage (int damage)
	{
		health -= damage;
	}

	public void Destroy()
	{
		health = _initialHealth;
		gameObject.GetComponent<PoolObject> ().ReturnToPool ();
	}

	public int GetHealth()
	{
		return health;
	}

	void Start()
	{
		_initialHealth = health;
		//DestroyObject += GameManager.Instanse.DamageController.OnDestroy;
	}
}
