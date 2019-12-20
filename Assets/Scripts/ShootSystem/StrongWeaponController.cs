using UnityEngine;
using System.Collections;

public class StrongWeaponController : MonoBehaviour {

	public float ammoRecoverTime;
	ShootModel _shotModel;
	// Use this for initialization
	void Start () {
		_shotModel = GameManager.Instanse.ShotModel;
		GameManager.Instanse.GameEventSystem.TryToFireWithStrongWeapon += OnTryToFireWithStrongWeapon;
	}

	public void OnTryToFireWithStrongWeapon(int damage, GameObject param2)
	{
		
		if(GameManager.Instanse.avaibleStrongBullet != 0 && _shotModel.IsReadyToFire)
		{
			FireWithStrongWeapon ();
			StartCoroutine(AwaitForRecoverBullet());
		}	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void FireWithStrongWeapon()
	{
		_shotModel.FireWithStrongWeapon ();
		GameManager.Instanse.avaibleStrongBullet--;
		GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.avaibleStrongBullet);
	}

	IEnumerator AwaitForRecoverBullet()
	{
		yield return new WaitForSeconds(ammoRecoverTime);
		GameManager.Instanse.avaibleStrongBullet++;
		GameManager.Instanse.GameEventSystem.UpdateStrongBulletValueLaunch(GameManager.Instanse.avaibleStrongBullet);
	}
}
