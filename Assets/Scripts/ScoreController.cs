using UnityEngine;
using UnityEngine.UI;

public class ScoreController
{
    Text _scoreDisplay;
    Text _gameOverScoreDisplay;
    public ScoreController(GameObject scoreDisplay)
    {
        GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
        GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroyObject;
        GameManager.Instanse.GameEventSystem.FinishGame += OnFinfishGame;
        GameManager.Instanse.Score = 0;
        _scoreDisplay = scoreDisplay.GetComponentInChildren<Text>();
        _gameOverScoreDisplay = GameManager.Instanse.GameOverDisplay.transform.GetChild(1).GetComponent<Text>();
    }

    void OnDestroyObject(int damage, GameObject victim)
    {
        int scoreIncrement = 0;
        switch (victim.name)
        {
            case "BigAsteroid_1":
                scoreIncrement = 75;
                break;
            case "BigAsteroid_2":
                scoreIncrement = 75;
                break;
            case "BigAsteroid_3":
                scoreIncrement = 75;
                break;
            case "SmallAsteroid_1":
                scoreIncrement = 150;
                break;
            case "UFO":
                scoreIncrement = 125;
                break;
        }
        GameManager.Instanse.Score += scoreIncrement;
        _scoreDisplay.text = GameManager.Instanse.Score.ToString();
    }

    void OnStartGame()
    {
        GameManager.Instanse.Score = 0;
        _scoreDisplay.text = "0";
        //GameManager.Instanse.GameOverDisplay.SetActive(false);
    }

    void OnFinfishGame()
    {
       _gameOverScoreDisplay.text = "Score : " + GameManager.Instanse.Score.ToString();
       //GameManager.Instanse.GameOverDisplay.SetActive(true);
    }

}
