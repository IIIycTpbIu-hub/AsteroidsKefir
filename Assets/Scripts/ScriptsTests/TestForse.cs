using UnityEngine;
using System.Collections;

public class TestForse : MonoBehaviour {

	Rigidbody _rigitBody;
	Vector3 _forse;
	// Use this for initialization
	void Start () {

		_forse = transform.position;
		_rigitBody = gameObject.GetComponent<Rigidbody> ();
		_rigitBody.AddForce (new Vector3(15f, 0, 0), ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
