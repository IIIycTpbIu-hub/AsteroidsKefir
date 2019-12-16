using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnRootPoint;
	public GameObject asteroidPrefab;
	//public Transform forsePoint;
	public float maxX;
	public float minX;
	public float maxY;
	public float minY;

	bool spawn = true;
	int _iterations = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(spawn)
			SpawnObject ();
	}

	void SpawnObject()
	{
		int childsCount = spawnRootPoint.transform.childCount;
		int randomElementIndex = Random.Range (0, childsCount);
		Transform[] childs = new Transform[childsCount];
		for (int i = 0; i < childsCount; i++) {
			childs[i] = spawnRootPoint.transform.GetChild(i);
		}

		GameObject asteroid = PoolManager.GetObject (asteroidPrefab.name, childs [randomElementIndex].transform.position, Quaternion.identity);


		if (asteroid.transform.position.x > 0) {
			minX = -7;
			maxX = -0.1f;

		} else {
			minX = 0.1f;
			maxX = 7;
		}
		if(asteroid.transform.position.y > 0)
		{
			minY = -4;
			maxY = -0.1f;
		}
		else
		{
			minY = 0.1f;
			maxY = 4;
		}
		Vector2 forseVector = GenerateRandomVector2ForsePonint (minX, maxX, minY, maxY);
		Debug.Log(forseVector.ToString());
		asteroid.GetComponent<Rigidbody2D> ().AddForce (forseVector, ForceMode2D.Impulse);

		//asteroid.GetComponent<Rigidbody2D> ().AddForce (forsePoint.position, ForceMode2D.Impulse);
		_iterations++;
		if(_iterations == 5)
			spawn = false;
		//Debug.Log (asteroid.name);

	}

	Vector2 GenerateRandomVector2ForsePonint(float minX, float maxX, float minY, float maxY)
	{
		float pointX = Random.Range (minX, maxX);
		float pointY = Random.Range (minY, maxY);
		Debug.Log (pointX + " " + pointY);
		return new Vector2 (pointX, pointY);
	}
}
