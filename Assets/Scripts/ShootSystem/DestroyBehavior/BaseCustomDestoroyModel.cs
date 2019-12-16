using UnityEngine;

public abstract class BaseCustomDestoroyModel : MonoBehaviour, IDestroyable {

	public int health;
	public WeaponEventHandler DestroyObj;
	
	public void TakeDamage (int damage)
	{
		health -= damage;
	}
	
	public abstract void Destroy ();
	
	public int GetHealth()
	{
		return health;
	}
}
