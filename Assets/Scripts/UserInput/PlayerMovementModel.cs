using UnityEngine;

/// <summary>
/// Модель движения корабля. 
/// </summary>
public class PlayerMovementModel
{
	GameObject _player;
	float _rotationSpeed;
	float _movingSpeed;
	Rigidbody2D _playerRigitBody;
	public PlayerMovementModel(GameObject player, float rotationSpeed, float movingSpeed)
	{
		_player = player;
		_playerRigitBody = _player.GetComponent<Rigidbody2D> ();
		_rotationSpeed = rotationSpeed;
		_movingSpeed = movingSpeed;
	}

	public void MoveTowards()
	{
		_playerRigitBody.AddForce (_player.transform.up * _movingSpeed, ForceMode2D.Force);
	}

	public void RotateLeft()
	{
		_player.transform.Rotate(new Vector3(0, 0, _rotationSpeed));
	}

	public void RotateRight()
	{
		_player.transform.Rotate(new Vector3(0, 0, -_rotationSpeed));
	}

	public GameObject GetPlayer()
	{
		return _player;
	}
}
