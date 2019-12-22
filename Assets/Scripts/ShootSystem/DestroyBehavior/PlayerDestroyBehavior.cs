using UnityEngine;

public class PlayerDestroyBehavior : BaseCustomDestoroyModel
{
    int _initialHealth;
    public override void CustomDestroyBehavior()
    {
        health = _initialHealth;
        GameManager.Instanse.GameEventSystem.FinishGameLaunch();
        gameObject.SetActive(false);
        GameManager.Instanse.IsGameOver = true;
    }

    void Start() 
    {
        GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
        GameManager.Instanse.GameEventSystem.Hit += OnHit;
        _initialHealth = health;
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
