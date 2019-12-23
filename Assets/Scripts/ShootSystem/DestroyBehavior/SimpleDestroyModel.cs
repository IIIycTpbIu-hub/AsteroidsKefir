using UnityEngine;

/// <summary>
/// Модель простого уничтожения объекта (На объекте должен находиться PoolObject).
/// </summary>
public class SimpleDestroyModel : MonoBehaviour ,IDestroyable {

	public int health;
	int _initialHealth;

	void Start()
	{
		_initialHealth = health;
	}
	public void TakeDamage (int damage)
	{
		health -= damage;
	}

	public void Destroy()
	{
		health = _initialHealth;
		PoolObject poolObj = gameObject.GetComponent<PoolObject> ();
		if(poolObj != null)
		{
			poolObj.ReturnToPool();
		}
	}

	public int GetHealth()
	{
		return health;
	}

	
}
