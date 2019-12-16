using UnityEngine;
using System.Collections;

public class TestForse2D : MonoBehaviour {

	Rigidbody2D _rigitBody;
	Vector2 _forse;
	// Use this for initialization
	void Start () {
		_forse = transform.position;
		_rigitBody = gameObject.GetComponent<Rigidbody2D> ();
		_rigitBody.AddForce (new Vector2(3f, 0), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
