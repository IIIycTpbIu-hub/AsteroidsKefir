using UnityEngine;

/// <summary>
/// Модель стрельбы
/// </summary>
public class ShootModel {

	public bool IsReadyToFire { get {return _isReadyToFire;}}
	GameObject _shotPoint;
	GameObject _player;
	bool _isReadyToFire;

	public ShootModel (GameObject player)
	{
		_shotPoint = player.transform.GetChild(0).gameObject;
		_player = player;
		_isReadyToFire = true;
	}


	public void Fire(float bulletSpeed, GameObject veapon)
	{
		if (_isReadyToFire) {
			Quaternion bulletQuaternion = _player.transform.rotation;
			GameObject shot = PoolManager.GetObject (veapon.name, _shotPoint.transform.position, bulletQuaternion);
			Rigidbody2D rigitBody = shot.GetComponent<Rigidbody2D>();
			if(rigitBody != null)
			{
				rigitBody.AddForce(_shotPoint.transform.up * bulletSpeed, ForceMode2D.Force);
			}	
			_isReadyToFire = false;
		}
	}

	public void SetOnReadyToFire()
	{
		_isReadyToFire = true;
	}
}
