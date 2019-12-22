using UnityEngine;

public class UFOMover : MonoBehaviour {


	public float speed;
	GameObject _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(_player != null)
		{
			Vector3 dir = _player.transform.position;
			Vector2 diraction = new Vector2 (dir.x - transform.position.x, dir.y - transform.position.y);
			transform.up = diraction;
			gameObject.transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, Time.deltaTime * speed);
		}
		
	}	
}
