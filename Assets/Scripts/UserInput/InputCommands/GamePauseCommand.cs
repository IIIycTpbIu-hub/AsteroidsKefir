using UnityEngine;

/// <summary>
/// Команда установки и снятия игры с паузы
/// </summary>
public class GamePauseCommand : ICommand {
	bool _isKeyPressed = false;

    public GamePauseCommand()
    {
        GameManager.Instanse.GameEventSystem.KeyUp += OnKeyUP;
    }
	public void Execute()
	{
        if(!_isKeyPressed)
        {
            bool isPaused = GameManager.Instanse.IsGamePaused;
            if(isPaused)
            {
                Time.timeScale = 1;
                GameManager.Instanse.IsGamePaused = false;
                GameManager.Instanse.GameEventSystem.PauseGameLaunch();
            }
		    else
            {
                Time.timeScale = 0;
                GameManager.Instanse.IsGamePaused = true;
                GameManager.Instanse.GameEventSystem.PauseGameLaunch();
            }
            _isKeyPressed = true;
        }
        
	}

    void OnKeyUP(KeyCode keyCode)
    {
        _isKeyPressed = false;
    }
}