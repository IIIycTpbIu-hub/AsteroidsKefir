using UnityEngine;

/// <summary>
/// Модель уничтожения игрока. При смерти игрока вызывыется событие конца игры
/// </summary>
public class PlayerDestroyBehavior : BaseCustomDestoroyModel
{
    int _initialHealth;
    
    void Start() 
    {
        GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
        GameManager.Instanse.GameEventSystem.Hit += OnHit;
        _initialHealth = health;
    }

    public override void CustomDestroyBehavior()
    {
        health = _initialHealth;
        GameManager.Instanse.GameEventSystem.FinishGameLaunch();
        gameObject.SetActive(false);
        GameManager.Instanse.IsGameOver = true;
    }

    void OnHit(int damage, GameObject victim)
    {
        if(victim.tag == gameObject.tag)
        {
            GameManager.Instanse.GameEventSystem.UpdateHealthValueLaunch(health);
        }
    }

    void OnStartGame()
    {
        gameObject.SetActive(true);
    }
}
