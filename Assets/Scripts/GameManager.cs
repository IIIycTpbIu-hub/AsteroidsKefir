using UnityEngine;

public class GameManager : MonoBehaviour {

	//-----------------Private fields------------------------
	/// <summary>
	/// Переключатель режима из спрайтового в полигональный
	/// </summary>
	bool _isSpriteMode = true;
	bool _isGameInitialized = false;
	GameObject _player;
	/// <summary>
	/// Слушает ввод с клавиатуры(не моно бехейвор)
	/// </summary>
	UserInputView _userInput;
	/// <summary>
	/// Контроллер ввода с клавиатуры
	/// </summary>
	UserInputController _inputController;
	/// <summary>
	/// Модель движения игрока
	/// </summary>
	PlayerMovementModel _playerMovementModel;
	/// <summary>
	/// Модель стрельбы
	/// </summary>
	ShootModel _shotModel;
	/// <summary>
	/// Контроллер нанесения урона
	/// </summary>
	DamageController _damageController;
	/// <summary>
	/// Модель спавна объектов
	/// </summary>
	ObjectSpawnModel _spawnModel;
	/// <summary>
	/// Контроллер спавна астероидов
	/// </summary>
	AsteroidsSpawnController _asteroidsSpawnController;
	/// <summary>
	/// Контроллер спавна НЛО
	/// </summary>
	UFOSpawnController _ufoSpawnController;
	/// <summary>
	/// Систама всех событий в игре
	/// </summary>
	GameEventSystem _gameEventSystem;

	PlayerPannelController _playerPannel;
	UIController _uiController;
	ScoreController _scoreController;
	static GameManager _instanse;
	static int _maxAsteroidsCount;
	//-----------------Private fields------------------------

	//-----------------Public fields-------------------------
	/// <summary>
	/// Инициализатор пула объектов
	/// </summary>
	public PoolSetup ObjectPoolSetup;
	/// <summary>
	/// Генератор звездного неба
	/// </summary>
	public GameObject StarsGenerator;
	/// <summary>
	/// Префаб игрока
	/// </summary>
	public GameObject PlayerPrefab;
	/// <summary>
	/// Скорость движения игрока
	/// </summary>
	public float MovingSpeed;
	/// <summary>
	/// Скорость поворота игрока
	/// </summary>
	public float RotationSpeed;
	/// <summary>
	/// Контроллер ожидания (используется контроллером спавна астероидов)
	/// </summary>
	public GameObject AwaitingControllerPrefab;
	/// <summary>
	/// Контроллер стрельбы из сильного оружия (зеленый и длинный лазеры)
	/// </summary>
	public GameObject StrongWeaponController;
	/// <summary>
	/// Слабое оружие
	/// </summary>
	public GameObject WeakWeaponPrefab;
	/// <summary>
	/// Скорость движения пули слабого оружия
	/// </summary>
	public float WeakWeaponSpeed;
	/// <summary>
	/// Сильное оружие
	/// </summary>
	public GameObject StrongWeaponPrefab;
	/// <summary>
	/// Максимальное кол-во выстрелов из сильного оружия
	/// </summary>
	public int MaxSrongBulletsCount;
	/// <summary>
	/// Скорость полета пули сильного оружия
	/// </summary>
	public float StrongWeaponSpeed;
	/// <summary>
	/// Лазер
	/// </summary>
	public GameObject StrongWeaponLaserPrefab;
	/// <summary>
	/// Массив префабов польших астероидов
	/// </summary>
	public GameObject[] BigAsteroids;
	/// <summary>
	/// Массив префабов маленьких астероидов
	/// </summary>
	public GameObject[] SmallAsteroids;
	/// <summary>
	/// Максимальное кол-во больших астероидов в сцене
	/// </summary>
	public int MaxAsteroidsCountInSciene;
	/// <summary>
	/// Массив префабов НЛО
	/// </summary>
	public GameObject[] UFOPrefabs;
	/// <summary>
	/// Максимальное кол-во НЛО в сцене
	/// </summary>
	public int MaxUFOScieneCount;
	/// <summary>
	/// Точки спавна 
	/// </summary>
	public GameObject AsteroidsSpawnPointsObject;
	/// <summary>
	/// Панель старта игры
	/// </summary>
	public GameObject StartGamePannel;
	/// <summary>
	/// Панель состояния игрока, содержит кол-во оставшихся жизней и выстрелов
	/// </summary>
	public GameObject PlayerPannel;
	/// <summary>
	/// Панель, отображающая кол-во набранных очков
	/// </summary>
	public GameObject ScoreDisplay;
	/// <summary>
	/// Панель, появляющаяся при смерти игрока
	/// </summary>
	public GameObject GameOverDisplay;
	/// <summary>
	/// Панель паузы
	/// </summary>
	public GameObject PauseDisplay;
	//-----------------Public fields-------------------------

	//-----------------Properties-------------------------
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

	public int CurrentAsteroidsCount {get; set;}

	public int CurrentUFOCount {get; set;}

	public int CurrentStrongBulletCount {get; set;}

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

	public ShootModel ShootModel {get {return _shotModel;}}

	public bool IsGamePaused {get; set;}

	public bool IsGameOver {get; set;}
	//-----------------Properties-------------------------

//-----------------Unity methods-------------------------
	void Awake()
	{
		_maxAsteroidsCount = MaxAsteroidsCountInSciene;
		if (_instanse) {
			DestroyImmediate(gameObject);
			return;
		}
		_instanse = this;
		DontDestroyOnLoad (gameObject);
		
	}
	
	void Update () {
		if(_userInput != null)
		{
			_userInput.ListenToKeysInput ();
		}
	}
//-----------------Unity methods-------------------------
	public void StartGame()
	{
		if(!_isGameInitialized)
		{
			InitializeGame();
		}
		GameEventSystem.StartGameLaunch();
		_player.transform.position = new Vector2(0, 0);
		_player.transform.rotation = Quaternion.identity;
		IsGameOver = false;
		
	}

	public void EndGame()
	{
		Application.Quit();
	}

	
	public void SwitchViualRegime(bool val)
	{
		_isSpriteMode = val;
		GameEventSystem.SwitchDisplayModeLaunch(_isSpriteMode);
	}

	public bool GetPoligonalView()
	{
		return _isSpriteMode;
	}


	void InitializeGame()
	{
		//инициализируем пулл объектов
		Instantiate (ObjectPoolSetup);

		//инициализируем звездное небо
		Instantiate (StarsGenerator);
		//инициализируем игрока
		_player = Instantiate (PlayerPrefab) as GameObject;
		_playerMovementModel = new PlayerMovementModel (_player, RotationSpeed, MovingSpeed);

		//инициализируем стрельбу и урон
		_shotModel = new ShootModel (_player);
		_damageController = new DamageController ();
		Instantiate (StrongWeaponController);

		//инициализируем пользовательский ввод
		_inputController = new UserInputController (_playerMovementModel, _shotModel);
		_userInput = _inputController.GetUserInputView ();

		//инициализируем UI
		_playerPannel = new PlayerPannelController(PlayerPannel);
		_uiController = new UIController();
		_gameEventSystem.UpdateStrongBulletValueLaunch(MaxSrongBulletsCount);
		_scoreController = new ScoreController(ScoreDisplay);
		
		//инициализируем спавн астероидов
		Instantiate(AwaitingControllerPrefab);
		_spawnModel = new ObjectSpawnModel (AsteroidsSpawnPointsObject);
		_asteroidsSpawnController = new AsteroidsSpawnController (_spawnModel);
		_ufoSpawnController = new UFOSpawnController(_spawnModel);

		_isGameInitialized = true;
	}

}
