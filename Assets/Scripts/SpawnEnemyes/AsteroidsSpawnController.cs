using UnityEngine;


public class AsteroidsSpawnController{


	GameObject[] _bigAsteroidPrefabs;
	GameObject[] _smallAsteroidPrefabs;
	ObjectSpawnModel _spawnModel;
	int _currentAsteroidsValue = 0;

	public AsteroidsSpawnController(GameObject[] bigAsteroidPrefabs, GameObject[] smallAsteroidPrefabs,
	                                ObjectSpawnModel spawnModel)
	{
		_bigAsteroidPrefabs = bigAsteroidPrefabs;
		_smallAsteroidPrefabs = smallAsteroidPrefabs;
		_spawnModel = spawnModel;

		while (_currentAsteroidsValue < GameManager.Instanse.MaxAsteroidsCount) {
			SpawnBigAsteroid();
		}
		GameManager.Instanse.GameEventSystem.AwaitComplit += OnAwaitComplite;
	}

	public void OnBigAsteroidDestroy(Vector2 deadPosition)
	{
		float newAsteroidSpawnTime = Random.Range(2f, 5f);
		GameManager.Instanse.GameEventSystem.AwaitForAwhileLaunch(newAsteroidSpawnTime);
		_currentAsteroidsValue--;
		//спавним два маленьких астероида(осколка)
		SpawnSmallAsteroid (deadPosition);
		SpawnSmallAsteroid (deadPosition);
		
	}

	void SpawnBigAsteroid()
	{
		if (_currentAsteroidsValue < GameManager.Instanse.MaxAsteroidsCount) {
			GameObject asteroid = ShooseRandomAsteroid(_bigAsteroidPrefabs);
			asteroid = _spawnModel.SpawnObject(asteroid);
			_spawnModel.AddForceToAnObject(asteroid);
			_currentAsteroidsValue++;
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

	void OnAwaitComplite(float time)
	{
		SpawnBigAsteroid ();
	}
}
