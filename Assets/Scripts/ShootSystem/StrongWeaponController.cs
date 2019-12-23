using UnityEngine;
using System.Collections;

/// <summary>
/// Контроллер выстрелов из тяжелого оружия. Производит стрельбу, ведет учет текущих пуль и время восстановления запаса патрон
/// </summary>
public class StrongWeaponController : MonoBehaviour {

	public float AmmoRecoverTime;
	int _bullets;
	float _playerDeadTime;
	ShootModel _shotModel;

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
		yield return new WaitForSeconds(AmmoRecoverTime);
		if(!GameManager.Instanse.IsGameOver && Time.time> _playerDeadTime + AmmoRecoverTime)
		{
			if(GameManager.Instanse.CurrentStrongBulletCount < GameManager.Instanse.MaxSrongBulletsCount)
			{
				GameManager.Instanse.CurrentStrongBulletCount++;
				GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.CurrentStrongBulletCount);
			}
		}
		
	}

	void OnTryToFireWithStrongWeapon(int damage, GameObject strongWeapon)
	{
		
		if(GameManager.Instanse.CurrentStrongBulletCount != 0 && _shotModel.IsReadyToFire)
		{
			_shotModel.Fire(GameManager.Instanse.StrongWeaponSpeed, strongWeapon);
			GameManager.Instanse.CurrentStrongBulletCount--;
			GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.CurrentStrongBulletCount);
			StartCoroutine(AwaitForRecoverBullet());
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
