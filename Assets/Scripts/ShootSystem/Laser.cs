using UnityEngine;

public class Laser : MonoBehaviour
{
    Transform  _shootPoint;
    void Start()
    {
        _shootPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
    }

    private void OnEnable() {
        Invoke("Off", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _shootPoint.rotation;
        transform.position = _shootPoint.position;
    }

    void Off()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

}
