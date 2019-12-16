using UnityEngine;
using System.Collections;

public class ShootModel {

	public bool IsReadyToFire { get {return _isReadyToFire;}}
	GameObject _shotPoint;
	GameObject _weakWeaponPrefab;
	float _weakWeaponSpeed;
	GameObject _strongWeaponPrefab;
	float _strongWeaponSpeed;
	GameObject _bullet;
	GameObject _player;
	bool _isReadyToFire;

	public ShootModel (GameObject shotPoint, GameObject weakWeapon, GameObject strongWeapon, float weakWeaponSpeed,
	                  float strongWeaponSpeed, GameObject player)
	{
		_shotPoint = shotPoint;
		_strongWeaponPrefab = strongWeapon;
		_weakWeaponPrefab = weakWeapon;
		_strongWeaponSpeed = strongWeaponSpeed;
		_weakWeaponSpeed = weakWeaponSpeed;
		_player = player;
		_isReadyToFire = true;
	}

	public void FireWithWeakWeapon()
	{
		_bullet = _weakWeaponPrefab;
		Fire (_weakWeaponSpeed);
	}

	public void FireWithStrongWeapon()
	{
		_bullet = _strongWeaponPrefab;
		Fire (_strongWeaponSpeed);
	}

	public void Fire(float bulletSpeed)
	{
		if (_isReadyToFire) {
			Quaternion bulletQuaternion = _player.transform.rotation;
			GameObject shot = PoolManager.GetObject (_bullet.name, _shotPoint.transform.position, bulletQuaternion);
			Rigidbody2D rigitBody = shot.GetComponent<Rigidbody2D>();
			rigitBody.AddForce(_shotPoint.transform.up * bulletSpeed, ForceMode2D.Force);
			_isReadyToFire = false;
		}
	}

	public void SetOnReadyToFire()
	{
		_isReadyToFire = true;
	}
}
