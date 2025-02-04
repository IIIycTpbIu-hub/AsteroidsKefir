﻿using UnityEngine;

/// <summary>
/// Контроллер спауна астероидов. Выполняет спавн и учет астероидов
/// </summary>
public class AsteroidsSpawnController{

	GameObject[] _bigAsteroidPrefabs;
	GameObject[] _smallAsteroidPrefabs;
	ObjectSpawnModel _spawnModel;

	public AsteroidsSpawnController(ObjectSpawnModel spawnModel)
	{
		_bigAsteroidPrefabs = GameManager.Instanse.BigAsteroids;
		_smallAsteroidPrefabs = GameManager.Instanse.SmallAsteroids;;
		_spawnModel = spawnModel;
		GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
		GameManager.Instanse.GameEventSystem.AwaitComplit += OnAwaitComplite;
		GameManager.Instanse.GameEventSystem.FinishGame += OnFinishGame;
		GameManager.Instanse.CurrentAsteroidsCount = 0;
	}

	public void OnBigAsteroidDestroy(Vector2 deadPosition)
	{
		GameManager.Instanse.CurrentAsteroidsCount--;
		if(!GameManager.Instanse.IsGameOver)
		{
			float newAsteroidSpawnTime = Random.Range(2f, 5f);
			GameManager.Instanse.GameEventSystem.AwaitForAwhileLaunch(newAsteroidSpawnTime);
			//спавним два маленьких астероида(осколка)
			SpawnSmallAsteroid (deadPosition);
			SpawnSmallAsteroid (deadPosition);
		}		
	}

	void SpawnBigAsteroid()
	{
		if (GameManager.Instanse.CurrentAsteroidsCount < GameManager.Instanse.MaxAsteroidsCount) {
			GameObject asteroid = ShooseRandomAsteroid(_bigAsteroidPrefabs);
			asteroid = _spawnModel.SpawnObject(asteroid);
			_spawnModel.AddForceToAnObject(asteroid);
			GameManager.Instanse.CurrentAsteroidsCount++;
		}
	}

	void SpawnSmallAsteroid(Vector2 position)
	{
		float x = Random.Range(-0.3f, 0.3f);
		float y = Random.Range(-0.3f, 0.3f);
		position.x += x;
		position.y += y;
		GameObject smallAsteroid = ShooseRandomAsteroid (_smallAsteroidPrefabs);
		smallAsteroid = _spawnModel.SpawnObject (smallAsteroid, position);
		_spawnModel.AddForceToAnObject(smallAsteroid);
	}

	GameObject ShooseRandomAsteroid(GameObject[] asteroidPrefabs)
	{
		int count = asteroidPrefabs.Length;
		int randomIndex = Random.Range (0, count);
		return asteroidPrefabs [randomIndex];
	}

	void OnStartGame()
	{
		while (GameManager.Instanse.CurrentAsteroidsCount < GameManager.Instanse.MaxAsteroidsCount) {
			SpawnBigAsteroid();
		}
	}

	void OnFinishGame()
	{
		GameManager.Instanse.CurrentAsteroidsCount = 0;
	}
	void OnAwaitComplite(float time)
	{
		if(!GameManager.Instanse.IsGameOver)
		{
			SpawnBigAsteroid ();
		}
		
	}
}
