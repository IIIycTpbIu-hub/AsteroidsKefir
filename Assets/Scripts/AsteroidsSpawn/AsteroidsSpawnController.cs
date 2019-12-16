using UnityEngine;
using System.Collections;

public class AsteroidsSpawnController{


	GameObject[] _bigAsteroidPrefabs;
	GameObject[] _smallAsteroidPrefabs;
	AsteroidsSpawnModel _asteroidsSpawnModel;
	int _currentAsteroidsValue = 0;

	public AsteroidsSpawnController(GameObject[] bigAsteroidPrefabs, GameObject[] smallAsteroidPrefabs,
	                                AsteroidsSpawnModel asteroidsSpawnModel)
	{
		_bigAsteroidPrefabs = bigAsteroidPrefabs;
		_smallAsteroidPrefabs = smallAsteroidPrefabs;
		_asteroidsSpawnModel = asteroidsSpawnModel;

		while (_currentAsteroidsValue < GameManager.Instanse.MaxAsteroidsCount) {
			SpawnBigAsteroid();
		}
	}

	public void OnBigAsteroidDestroy(Vector2 deadPosition)
	{
		_currentAsteroidsValue--;
		SpawnBigAsteroid ();
		//спавним два маленьких астероида
		SpawnSmallAsteroid (deadPosition);
		SpawnSmallAsteroid (deadPosition);
	}

	void SpawnBigAsteroid()
	{
		if (_currentAsteroidsValue < GameManager.Instanse.MaxAsteroidsCount) {
			GameObject asteroid = ShooseRandomAsteroid(_bigAsteroidPrefabs);
			_asteroidsSpawnModel.SpawnAsteroid(asteroid);
			_currentAsteroidsValue++;
		}
	}

	void SpawnSmallAsteroid(Vector2 position)
	{
		GameObject smallAsteroid = ShooseRandomAsteroid (_smallAsteroidPrefabs);
		_asteroidsSpawnModel.SpawnAsteroid (smallAsteroid, position);
	}

	GameObject ShooseRandomAsteroid(GameObject[] asteroidPrefabs)
	{
		int count = asteroidPrefabs.Length;
		int randomIndex = Random.Range (0, count);
		return asteroidPrefabs [randomIndex];
	}
}
