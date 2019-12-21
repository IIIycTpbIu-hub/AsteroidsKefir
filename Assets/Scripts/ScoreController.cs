using UnityEngine;
using UnityEngine.UI;

public class ScoreController
{
    Text _scoreDisplay;
    public ScoreController(GameObject scoreDisplay)
    {
        GameManager.Instanse.GameEventSystem.DestroyObject += OnDestroyObject;
        GameManager.Instanse.Score = 0;
        _scoreDisplay = scoreDisplay.GetComponentInChildren<Text>();
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
}
