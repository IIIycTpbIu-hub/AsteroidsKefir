using UnityEngine;

/// <summary>
/// Реагирует на столкновения между объеквтов и вызывает событие столкновения объектов. Доложна находиться на всех объектах, наносящих и получающих урон
/// </summary>
public class ObjectCollisionView : MonoBehaviour {
	
	public int Damage;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag != tag)
		{
			GameManager.Instanse.GameEventSystem.HitEventLaunch (Damage, other.gameObject);
		}
		
	}	
}
