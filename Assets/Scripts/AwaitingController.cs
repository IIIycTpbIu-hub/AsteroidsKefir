using System.Collections;
using UnityEngine;

/// <summary>
/// Контроллер ожидания. Запускает корутину и уведомляет о ее завершении.(Не удачное решение. Используется только контроллером астероидов)
/// </summary>
public class AwaitingController : MonoBehaviour
{
    float _awaitingTime;

    void Start()
    {
        GameManager.Instanse.GameEventSystem.AwaitForAwhile += OnAwaitForTime;
    }

    IEnumerator AwaitForTime()
    {
        yield return new WaitForSeconds(_awaitingTime);
        GameManager.Instanse.GameEventSystem.AwaitComplitLaunch(_awaitingTime);
        _awaitingTime = 0f;
    }
    
    void OnAwaitForTime(float time)
    {
        _awaitingTime = time;
        StartCoroutine("AwaitForTime");
    } 

    
}
