using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Пулл объектов одного типа
/// </summary>
public class ObjectPooling 
{
	List<PoolObject> _poolObjects;
	Transform _poolObjectsParent;

	int _objectIndex = 0;

	public void Initialize(int count, PoolObject objectPrefab, Transform parent)
	{
		_poolObjects = new List<PoolObject> ();
		_poolObjectsParent = parent;
		//Далее добавляем нужное колличество объектов в коллекцию
		for(int i = 0; i < count; i++)
		{
			AddObject(objectPrefab, _poolObjectsParent);
		}
	}

	public PoolObject GetObject()
	{
		if(_objectIndex >= _poolObjects.Count)
		{
			_objectIndex = 0;
		}
		int tempIndex = _objectIndex;
		_objectIndex++;

		if(_poolObjects[tempIndex].gameObject.activeInHierarchy)
		{
			//обнуляем объекты
			_poolObjects[tempIndex].gameObject.SetActive(false);
			_poolObjects[tempIndex].gameObject.SetActive(true);
		}
		return _poolObjects[tempIndex];

		/* for(int i = 0; i < _poolObjects.Count; i++)
		{
			if(!_poolObjects[i].gameObject.activeInHierarchy)
			{
				return _poolObjects[i];
			}
		}
		//добавить проверку на то, что выданы все объекты из пула
		return null; */
		//решил не делать, вместо этого перевыдаем первый выданный объект
	}

	void AddObject(PoolObject objectPrefab, Transform parent)
	{
		GameObject tempObject = GameObject.Instantiate (objectPrefab.gameObject);
		tempObject.name = objectPrefab.name;
		tempObject.transform.SetParent (parent);
		_poolObjects.Add (tempObject.GetComponent<PoolObject> ());
		tempObject.SetActive (false);
	}
}
