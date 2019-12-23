using UnityEngine;

/// <summary>
/// Лазер. Появляется в точке выстрела на определенное время
/// </summary>
public class Laser : MonoBehaviour
{
    public float ActionTimeLenght;
    Transform  _shootPoint;
    
    void Start()
    {
        _shootPoint = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
    }

    void Update()
    {
        transform.rotation = _shootPoint.rotation;
        transform.position = _shootPoint.position;
    }

    void OnEnable() {
        Invoke("Off", ActionTimeLenght);
    }

    void Off()
    {
        gameObject.GetComponent<PoolObject>().ReturnToPool();
    }

}
