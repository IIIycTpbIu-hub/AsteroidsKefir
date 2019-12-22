using UnityEngine;
using System.Collections;

public class StrongWeaponController : MonoBehaviour {

	public float ammoRecoverTime;
	ShootModel _shotModel;
	// Use this for initialization
	void Start () {
		_shotModel = GameManager.Instanse.ShootModel;
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeapon += OnTryToFireWithStrongWeapon;
	}

	public void OnTryToFireWithStrongWeapon(int damage, GameObject strongWeapon)
	{
		
		if(GameManager.Instanse.avaibleStrongBullet != 0 && _shotModel.IsReadyToFire)
		{
			_shotModel.Fire(GameManager.Instanse.strongWeaponSpeed, strongWeapon);
			GameManager.Instanse.avaibleStrongBullet--;
			GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.avaibleStrongBullet);
			StartCoroutine(AwaitForRecoverBullet());
		}	
	}

	IEnumerator AwaitForRecoverBullet()
	{
		yield return new WaitForSeconds(ammoRecoverTime);
		GameManager.Instanse.avaibleStrongBullet++;
		GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.avaibleStrongBullet);
	}
}
