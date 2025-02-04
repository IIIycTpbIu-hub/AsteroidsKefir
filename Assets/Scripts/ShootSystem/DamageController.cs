﻿using UnityEngine;

/// <summary>
/// Контроллер нанесения урона. Урон наносится при наличии на объекте компонента IDestroyable
/// </summary>
public class DamageController{
	
	HealthModel _healthModel;

	public DamageController()
	{
		_healthModel = new HealthModel ();
		GameManager.Instanse.GameEventSystem.Hit += OnHit;
		GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroy;
	}

	public void OnHit(int damage, GameObject victim)
	{
		IDestroyable destroyModel =  victim.GetComponent<IDestroyable>();
			if(destroyModel != null)
			{
				bool killed = _healthModel.SetDamage (damage, destroyModel);
				if(killed)
				{
					GameManager.Instanse.GameEventSystem.DestroyObjectEventLaunch(damage, victim);
				}
			}	
	}

	public void OnDestroy(int damage, GameObject victim)
	{
		IDestroyable component = victim.GetComponent<IDestroyable> ();
		if (component is BigAsteroidDestroyModel) {
			GameManager.Instanse.AsteroidsSpawnController.OnBigAsteroidDestroy (victim.transform.position);
		}
		if(component is UFODestroyModel)
		{
			GameManager.Instanse.UFOSpawnController.OnUFODestroy();
		}
		component.Destroy ();
	}
}
