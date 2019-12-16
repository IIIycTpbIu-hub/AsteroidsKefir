using UnityEngine;

public class LightBurstSpawnerMover : MonoBehaviour {


	public float speed;
	GameObject _player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		gameObject.transform.position = Vector3.MoveTowards (
//			this.transform.position, new Vector3 (this.transform.position.x, _player.transform.position.y,
//		                                     this.transform.position.z), Time.deltaTime * 10f);

		_player = GameObject.FindGameObjectWithTag ("Player");

		//transform.LookAt (_player.transform.position);

		//Vector3 dir = _player.transform.position;
		//var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		Vector3 dir = _player.transform.position;
		Vector2 diraction = new Vector2 (dir.x - transform.position.x, dir.y - transform.position.y);
		transform.up = diraction;

		gameObject.transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, Time.deltaTime * speed);
	}	
}
