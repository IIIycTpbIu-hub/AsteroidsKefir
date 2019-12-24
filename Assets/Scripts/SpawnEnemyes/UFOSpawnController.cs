using UnityEngine;

/// <summary>
/// Контроллер спауна НЛО. Выполняет спаун и учет
/// </summary>
public class UFOSpawnController
{
    GameObject[] _ufoPrefabs;
    ObjectSpawnModel _spawnModel;
    float _newUFOSpawnTime;
    int _killedAsteroidsBeforeSpawn = 20;
    int _killedAsteroids = 0;

    public UFOSpawnController(ObjectSpawnModel spawnModel)
    {
        _spawnModel = spawnModel;
        _ufoPrefabs = GameManager.Instanse.UFOPrefabs;
        GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroyObject;
        GameManager.Instanse.GameEventSystem.FinishGame += OnFinishGame;
        GameManager.Instanse.CurrentUFOCount = 0;
    }

    void SpawnUFO()
    {
        if(GameManager.Instanse.CurrentUFOCount < GameManager.Instanse.MaxUFOScieneCount && !GameManager.Instanse.IsGameOver)
        {
            GameObject ufo = ShooseRandomUFO();
            ufo = _spawnModel.SpawnObject(ufo);
            GameManager.Instanse.CurrentUFOCount++;
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
        GameManager.Instanse.CurrentUFOCount--;
    }
    void OnDestroyObject(int dmg, GameObject victim)
    {
        if(victim.tag == "Asteroid")
        {
            _killedAsteroids++;   
        }

        if(_killedAsteroids == _killedAsteroidsBeforeSpawn)
        {
            while(GameManager.Instanse.CurrentUFOCount < GameManager.Instanse.MaxUFOScieneCount)
            {
                SpawnUFO();
            }
            _killedAsteroids = 0;
        }
    }

    public void OnFinishGame()
    {
        GameManager.Instanse.CurrentUFOCount = 0;
    }
}
