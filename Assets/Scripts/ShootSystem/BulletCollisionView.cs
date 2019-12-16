using UnityEngine;
using System.Collections;

//public delegate void WeaponEventHandler(GameObject weapon ,GameObject victim);

public class BulletCollisionView : MonoBehaviour {
	
	public int Damage;
	//public WeaponEventHandler Hit;
	
	void Start () {
		//подписывает контроллер на себя
		//Hit += GameManager.Instanse.DamageController.OnHit;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		GameManager.Instanse.GameEventSystem.HitEventLaunch (gameObject, other.gameObject);		
	}	
}
