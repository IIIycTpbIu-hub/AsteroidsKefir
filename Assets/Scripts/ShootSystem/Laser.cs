using UnityEngine;

public class Laser : MonoBehaviour
{
    Transform  _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _playerTransform.rotation;
    }

}
