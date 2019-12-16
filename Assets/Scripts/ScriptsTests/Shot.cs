using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public Transform shotPoint;
	public GameObject[] shotPrefab;
	public float bulletSpeed;

	Quaternion _bulletQuaternion;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			Fire (shotPrefab[0]);
//		if (Input.GetMouseButtonDown(0))
//			Fire (shotPrefab[1]);
	}

	void Fire(GameObject shotPrefab)
	{
		_bulletQuaternion = gameObject.transform.rotation;
		//GameObject shot = Instantiate(shotPrefab, shotPoint.transform.position, _bulletQuaternion) as GameObject;
		GameObject shot = PoolManager.GetObject (shotPrefab.name, shotPoint.transform.position, _bulletQuaternion);
		Rigidbody2D rigitBody = shot.GetComponent<Rigidbody2D>();
		rigitBody.AddForce(shotPoint.transform.up * bulletSpeed, ForceMode2D.Force);
	}
}
