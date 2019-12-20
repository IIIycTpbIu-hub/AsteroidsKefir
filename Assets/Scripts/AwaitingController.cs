using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwaitingController : MonoBehaviour
{
    float _awaitingTime;

    void Start()
    {
        GameManager.Instanse.GameEventSystem.AwaitForAwhile += OnAwaitForTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAwaitForTime(float time)
    {
        _awaitingTime = time;
        StartCoroutine("AwaitForTime");
    } 

    IEnumerator AwaitForTime()
    {
        yield return new WaitForSeconds(_awaitingTime);
        GameManager.Instanse.GameEventSystem.AwaitComplitLaunch(_awaitingTime);
        _awaitingTime = 0f;
    }
}
