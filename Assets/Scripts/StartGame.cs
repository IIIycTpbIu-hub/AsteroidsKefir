using UnityEngine;
/// <summary>
/// Начало игры. Ожидает пробела для инициализации
/// </summary>
public class StartGame : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instanse.StartGame();
            gameObject.SetActive(false);
        }
    }
}
