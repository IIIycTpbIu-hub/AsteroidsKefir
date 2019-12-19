using UnityEngine;
using System.Collections;

public class DamageController{
	
	HealthModel _healthModel;

	public DamageController()
	{
		_healthModel = new HealthModel ();
		GameManager.Instanse.GameEventSystem.Hit += OnHit;
		GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroy;
	}

	public void OnHit(GameObject weapon, GameObject victim)
	{
		if(weapon.tag != victim.tag)//одноименные объекты не должны наносить друг другу урон
		{
			IDestroyable weponDestroyModel = weapon.GetComponent<IDestroyable>();
			IDestroyable victimDestroyModel = victim.GetComponent<IDestroyable> ();
			if(weponDestroyModel != null)
			{
				weponDestroyModel.Destroy();
			}
			if (victimDestroyModel != null) {
				bool killed = _healthModel.SetDamage (1, victimDestroyModel);
				if(killed)
				{
					GameManager.Instanse.GameEventSystem.DestroyObjectEventLaunch(weapon, victim);
				}
			}
		}
		
	}

	public void OnDestroy(GameObject weapon, GameObject victim)
	{
		IDestroyable component = victim.GetComponent<IDestroyable> ();
		if (component is BigAsteroidDestroyModel) {
			GameManager.Instanse.AsteroidsSpawnController.OnBigAsteroidDestroy (victim.transform.position);
		}
		component.Destroy ();
	}
}
