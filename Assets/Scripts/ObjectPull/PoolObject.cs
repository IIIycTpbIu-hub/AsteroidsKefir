using UnityEngine;
using System.Collections;

[AddComponentMenu("Pool/PoolObject")]
public class PoolObject : MonoBehaviour
{
	public void ReturnToPool () {
		gameObject.SetActive (false);
	}
} 
