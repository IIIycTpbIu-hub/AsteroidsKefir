using UnityEngine;

public abstract class BaseCustomDestoroyModel : MonoBehaviour, IDestroyable {

	public int health;
	public WeaponEventHandler DestroyObj;

		
	public void TakeDamage (int damage)
	{
		health -= damage;
	}
	
	public void Destroy ()
	{
		CustomDestroyBehavior();
		gameObject.GetComponent<PoolObject> ().ReturnToPool ();
	}
	public int GetHealth()
	{
		return health;
	}

	public abstract void CustomDestroyBehavior();
}
