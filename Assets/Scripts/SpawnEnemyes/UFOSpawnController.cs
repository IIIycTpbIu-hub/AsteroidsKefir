using UnityEngine;

public class UFOSpawnController
{
    GameObject[] _ufoPrefabs;
    ObjectSpawnModel _spawnModel;
    int _currentUFOCount = 0;
    float _newUFOSpawnTime;
    int _killedAsteroidsBeforeSpawn = 20;
    int _killedAsteroids = 0;

    public UFOSpawnController(ObjectSpawnModel spawnModel)
    {
        _spawnModel = spawnModel;
        _ufoPrefabs = GameManager.Instanse.UFOPrefabs;
        GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroyObject;
    }

    void SpawnUFO()
    {
        if(_currentUFOCount < GameManager.Instanse.maxUFOScieneCount)
        {
            GameObject ufo = ShooseRandomUFO();
            ufo = _spawnModel.SpawnObject(ufo);
            _currentUFOCount++;
        }
    }

    GameObject ShooseRandomUFO()
	{
		int count = _ufoPrefabs.Length;
		int randomIndex = Random.Range (0, count);
		return _ufoPrefabs [randomIndex];
	}

    public void OnUFODestroy()
    {
        _newUFOSpawnTime = Random.Range(10f, 15f);
		GameManager.Instanse.GameEventSystem.AwaitForAwhileLaunch(_newUFOSpawnTime);
        _currentUFOCount--;
    }
    void OnDestroyObject(int dmg, GameObject victim)
    {
        if(victim.tag == "Asteroid")
        {
            _killedAsteroids++;   
        }

        if(_killedAsteroids == _killedAsteroidsBeforeSpawn)
        {
            SpawnUFO();
            _killedAsteroids = 0;
        }
    }
}
