using UnityEngine;
using System.Collections;

public class StarsGenerator : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public int starsCount;
	public GameObject[] starPrefabs;

	void Start () {
		GenerateStarsSky ();
		Destroy(gameObject, 1f);
	}
	

	void GenerateStarsSky()
	{
		GameObject stars = new GameObject();
		stars.name = "Stars";
		for (int i = 0; i < starsCount; i++) {
			GameObject starPrefab = starPrefabs[Random.Range(0, starPrefabs.Length)];
			Vector2 starPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
			GameObject star = Instantiate(starPrefab, starPosition, Quaternion.identity) as GameObject;
			star.transform.SetParent(stars.transform);
		}
	}
}
