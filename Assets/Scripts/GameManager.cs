using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public PoolSetup objectPoolSetup;
	public GameObject starsGenerator;
	public GameObject playerPrefab;
	public float movingSpeed;
	public float rotationSpeed;
	public GameObject awaitingControllerPrefab;
	public GameObject strongWeaponController;
	public GameObject weakWeaponPrefab;
	public float weakWeaponSpeed;
	public GameObject strongWeaponPrefab;
	public int avaibleStrongBullet;
	public float strongWeaponSpeed;
	public GameObject strongWeaponLaserPrefab;
	public GameObject[] bigAsteroids;
	public GameObject[] smallAsteroids;
	public int maxAsteroidsCountInSciene;
	public GameObject[] UFOPrefabs;
	public int maxUFOScieneCount;
	public GameObject asteroidsSpawnPointsObject;

	public GameObject StartGamePannel;
	public GameObject PlayerPannel;
	public GameObject ScoreDisplay;
	public GameObject GameOverDisplay;
	public GameObject PauseDisplay;

	
	bool _isSpriteMode = true;
	UserInputView _userInput;
	PlayerMovementModel _playerMovementModel;
	ShootModel _shotModel;
	UserInputController _inputController;
	DamageController _damageController;
	ObjectSpawnModel _spawnModel;
	AsteroidsSpawnController _asteroidsSpawnController;
	UFOSpawnController _ufoSpawnController;
	GameEventSystem _gameEventSystem;

	PlayerPannelController _playerPannel;

	ScoreController _scoreController;
	static GameManager _instanse;
	static int _maxAsteroidsCount;
	
	public static GameManager Instanse { get {return _instanse;}}

	public GameEventSystem GameEventSystem { get
		{
			if(_gameEventSystem == null)
			{
				_gameEventSystem = new GameEventSystem();
			}
			return _gameEventSystem;
		}
		private set {}}

	public int MaxAsteroidsCount {get {return _maxAsteroidsCount;} }

	public DamageController DamageController
	{
		get {
			if(_damageController == null)
			{
				_damageController = new DamageController();
			}
			return _damageController;
		}
	}

	public AsteroidsSpawnController AsteroidsSpawnController { get {return _asteroidsSpawnController;}}

	public UFOSpawnController UFOSpawnController {get {return _ufoSpawnController;}}

	public int Score {get; set;}

	public ShootModel ShotModel {get {return _shotModel;}}

	public bool IsGamePaused {get; set;}

	public void SetPoligonalView(bool val)
	{
		_isSpriteMode = val;
		GameEventSystem.SwitchDisplayModeLaunch(_isSpriteMode);
	}

	public bool GetPoligonalView()
	{
		return _isSpriteMode;
	}

	void Awake()
	{
		_maxAsteroidsCount = maxAsteroidsCountInSciene;
		if (_instanse) {
			DestroyImmediate(gameObject);
			return;
		}
		_instanse = this;
		DontDestroyOnLoad (gameObject);
		
	}


	// Use this for initialization
	void Start () {
		InitializeGame ();
	}
	
	// Update is called once per frame
	void Update () {
		_userInput.Update ();
	}

	void InitializeGame()
	{
		//инициализируем пулл объектов
		Instantiate (objectPoolSetup);
		//инициализируем звездное небо
		Instantiate (starsGenerator);
		_damageController = new DamageController ();
		//инициализируем игрока
		
		GameObject player = Instantiate (playerPrefab) as GameObject;
		_playerMovementModel = new PlayerMovementModel (player, rotationSpeed, movingSpeed);
		_shotModel = new ShootModel (player);
		_inputController = new UserInputController (_playerMovementModel, _shotModel);
		_userInput = _inputController.GetUserInputView ();

		Instantiate (strongWeaponController);

		//инициализируем UI
		_playerPannel = new PlayerPannelController(PlayerPannel);
		_gameEventSystem.UpdateStrongBulletValueLaunch(avaibleStrongBullet);
		_scoreController = new ScoreController(ScoreDisplay);
		//инициализируем спавн астероидов
		Instantiate(awaitingControllerPrefab);
		_spawnModel = new ObjectSpawnModel (asteroidsSpawnPointsObject);
		_asteroidsSpawnController = new AsteroidsSpawnController (_spawnModel);
		_ufoSpawnController = new UFOSpawnController(_spawnModel);
	}
}
