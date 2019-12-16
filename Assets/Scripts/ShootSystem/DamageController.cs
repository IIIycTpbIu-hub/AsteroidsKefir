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
		IDestroyable destroyModel = victim.GetComponent<IDestroyable> ();
		weapon.GetComponent<IDestroyable>().Destroy ();
		if (destroyModel != null) {
			bool killed = _healthModel.SetDamage (1, destroyModel);
			if(killed)
			{
				GameManager.Instanse.GameEventSystem.DestroyObjectEventLaunch(weapon, victim);
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
