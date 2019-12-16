﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("Pool/PoolSetup")]
public class PoolSetup : MonoBehaviour {

	[SerializeField] 
	private PoolManager.PoolFields[] _pools;

	void OnValidate() {
		for (int i = 0; i < _pools.Length; i++) {
			_pools[i].name = _pools[i].prefab.name;
		}
	}
	
	void Awake() {
		Initialize ();
	}
	
	void Initialize () {
		PoolManager.Initialize(_pools);
	}
}
