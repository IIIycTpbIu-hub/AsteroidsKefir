﻿using UnityEngine;

/// <summary>
/// Модель спауна объектов типа PoolObject
/// </summary>
public class ObjectSpawnModel {

	GameObject _spawnRootPoint;
	int _rootPointChildsCount;
	Transform[] _spawnPoints;
	float _maxX;
	float _minX;
	float _maxY;
	float _minY;

	public ObjectSpawnModel(GameObject spawnRootPoint)
	{
		_spawnRootPoint = spawnRootPoint;
		_rootPointChildsCount = _spawnRootPoint.transform.childCount;
		_spawnPoints = new Transform[_rootPointChildsCount];
		for (int i = 0; i < _rootPointChildsCount; i++) {
			_spawnPoints[i] = spawnRootPoint.transform.GetChild(i);
		}
	}


	public GameObject SpawnObject(GameObject asteroidPrefab)
	{
		int randomElementIndex = Random.Range (0, _rootPointChildsCount);
		GameObject spawingObject = PoolManager.GetObject (asteroidPrefab.name,
		                                             _spawnPoints [randomElementIndex].transform.position,
		                                             Quaternion.identity);
		return spawingObject;
	}

	public GameObject SpawnObject(GameObject objectPrefab, Vector2 position)
	{
		GameObject spawingObject = PoolManager.GetObject (objectPrefab.name,
		                                             position, Quaternion.identity);
		
		return spawingObject;
	}

	public void AddForceToAnObject(GameObject forsingObject)
	{
		Rigidbody2D body = forsingObject.GetComponent<Rigidbody2D>();
		if(body != null)
		{
			CalculateForseVectorsDiapazon (forsingObject);
			Vector2 forseVector = GenerateRandomVector2ForsePonint (_minX, _maxX, _minY, _maxY);
			body.AddForce(forseVector, ForceMode2D.Impulse);
		}
	}
	void CalculateForseVectorsDiapazon(GameObject asteroid)
	{
		if (asteroid.transform.position.x > 0) {
			_minX = -7;
			_maxX = -0.1f;
			
		} else {
			_minX = 0.1f;
			_maxX = 7;
		}
		if(asteroid.transform.position.y > 0)
		{
			_minY = -4;
			_maxY = -0.1f;
		}
		else
		{
			_minY = 0.1f;
			_maxY = 4;
		}
		
	}

	Vector2 GenerateRandomVector2ForsePonint(float minX, float maxX, float minY, float maxY)
	{
		float pointX = Random.Range (minX, maxX);
		float pointY = Random.Range (minY, maxY);
		return new Vector2 (pointX, pointY);
	}
}
