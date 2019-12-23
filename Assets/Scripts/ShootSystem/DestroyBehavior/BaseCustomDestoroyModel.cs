using UnityEngine;

/// <summary>
/// Базовый класс модели уничтожения объекта с изменяемым поведением после смерти. Потомок должен переопределить его.
/// </summary>
public abstract class BaseCustomDestoroyModel : MonoBehaviour, IDestroyable {

	public int health;
		
	public void TakeDamage (int damage)
	{
		health -= damage;
	}
	
	public void Destroy ()
	{
		CustomDestroyBehavior();
		PoolObject poolObjectComponent = gameObject.GetComponent<PoolObject> ();
		if(poolObjectComponent != null)
		{
			poolObjectComponent.ReturnToPool();
		}
	}
	public int GetHealth()
	{
		return health;
	}

	public abstract void CustomDestroyBehavior();
}
