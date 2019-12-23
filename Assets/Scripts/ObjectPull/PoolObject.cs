using UnityEngine;

/// <summary>
/// Представляет собой объект пула 
/// </summary>
[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour
{

	void Start() 
	{
		GameManager.Instanse.GameEventSystem.FinishGame += OnGameFinish;
	}

	public void ReturnToPool () 
	{
		gameObject.SetActive (false);
	}

	void OnGameFinish()
	{
		if(gameObject.activeInHierarchy)
		{
			ReturnToPool();
		}
	}
} 
