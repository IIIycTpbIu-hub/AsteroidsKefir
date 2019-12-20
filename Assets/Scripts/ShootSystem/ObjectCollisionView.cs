using UnityEngine;
using System.Collections;

//public delegate void WeaponEventHandler(GameObject weapon ,GameObject victim);

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
