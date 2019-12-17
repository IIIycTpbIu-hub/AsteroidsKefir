using UnityEngine;

public class GamePauseCommand : ICommand {
	bool _isKeyPressed = false;
    GameObject _pausePannel;

    public GamePauseCommand()
    {
        GameManager.Instanse.GameEventSystem.KeyUp += OnKeyUP;
        //
        _pausePannel = GameManager.Instanse.PauseDisplay;
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
                _pausePannel.SetActive(false);
            }
		    else
            {
                Time.timeScale = 0;
                GameManager.Instanse.IsGamePaused = true;
                _pausePannel.SetActive(true);
            }
            _isKeyPressed = true;
        }
        
	}

    void OnKeyUP(KeyCode keyCode)
    {
        _isKeyPressed = false;
    }
}