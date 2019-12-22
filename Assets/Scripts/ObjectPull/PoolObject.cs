using UnityEngine;

[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour
{
	public void ReturnToPool () 
	{
		gameObject.SetActive (false);
	}

	void Start() 
	{
		GameManager.Instanse.GameEventSystem.FinishGame += OnGameFinish;
	}
	void OnGameFinish()
	{
		if(gameObject.activeInHierarchy)
		{
			ReturnToPool();
		}
	}
} 
