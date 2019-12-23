using UnityEngine;
using System.Collections;

public class StrongWeaponController : MonoBehaviour {

	public float ammoRecoverTime;
	int _bullets;
	float _playerDeadTime;
	ShootModel _shotModel;

	public void OnTryToFireWithStrongWeapon(int damage, GameObject strongWeapon)
	{
		
		if(GameManager.Instanse.CurrentStrongBulletCount != 0 && _shotModel.IsReadyToFire)
		{
			_shotModel.Fire(GameManager.Instanse.StrongWeaponSpeed, strongWeapon);
			GameManager.Instanse.CurrentStrongBulletCount--;
			GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.CurrentStrongBulletCount);
			StartCoroutine(AwaitForRecoverBullet());
		}	
	}
	void Start () {
		_shotModel = GameManager.Instanse.ShootModel;
		GameManager.Instanse.GameEventSystem.StartGame += OnGameStart;
		GameManager.Instanse.GameEventSystem.FinishGame += OnFinishGame;
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeapon += OnTryToFireWithStrongWeapon;
		_bullets = GameManager.Instanse.MaxSrongBulletsCount;
		GameManager.Instanse.CurrentStrongBulletCount = _bullets;
	}

	IEnumerator AwaitForRecoverBullet()
	{
		yield return new WaitForSeconds(ammoRecoverTime);
		if(!GameManager.Instanse.IsGameOver && Time.time> _playerDeadTime + ammoRecoverTime)
		{
			if(GameManager.Instanse.CurrentStrongBulletCount < GameManager.Instanse.MaxSrongBulletsCount)
			{
				GameManager.Instanse.CurrentStrongBulletCount++;
				GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.CurrentStrongBulletCount);
			}
		}
		
	}

	void OnGameStart()
	{
		GameManager.Instanse.CurrentStrongBulletCount = _bullets;
		GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.CurrentStrongBulletCount);
	}

	void OnFinishGame()
	{
		_playerDeadTime = Time.time;
	}
}
