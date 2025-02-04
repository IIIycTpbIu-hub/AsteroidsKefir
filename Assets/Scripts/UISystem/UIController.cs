﻿using UnityEngine;

/// <summary>
/// Контроллер пользовательского UI. Выполняет переключение визульных представлений в зависимости от состояния игры
/// </summary>
public class UIController
{
    GameObject _startPannel;
    GameObject _pausePannel;
    GameObject _playerPannel;
    GameObject _scorePannel;
    GameObject _gameOverPannel;

    public UIController()
    {
        _startPannel = GameManager.Instanse.StartGamePannel;
        _pausePannel = GameManager.Instanse.PauseDisplay;
        _playerPannel = GameManager.Instanse.PlayerPannel;
        _scorePannel = GameManager.Instanse.ScoreDisplay;
        _gameOverPannel = GameManager.Instanse.GameOverDisplay;
        GameManager.Instanse.GameEventSystem.StartGame += OnStartGame;
        GameManager.Instanse.GameEventSystem.PauseGame += OnPauseGame;
        GameManager.Instanse.GameEventSystem.FinishGame += OnFinishGame;
    }

    void OnStartGame()
    {
        _playerPannel.SetActive(true);
        _scorePannel.SetActive(true);
        _gameOverPannel.SetActive(false);
    }

    void OnPauseGame()
    {
        bool pause = GameManager.Instanse.IsGamePaused;
        _pausePannel.SetActive(pause);
    }
    void OnFinishGame()
    {
        _playerPannel.SetActive(false);
        _scorePannel.SetActive(false);
        _gameOverPannel.SetActive(true);
    }
}
