using UnityEngine;
namespace CodeBase
{
    public class Bootstrap : MonoBehaviour
    {
        public Game _game;
        public const string PLAYER_PATH = "Player/FPS_PLAYER";
        public IInputService _inputService;
        public SceneLoadService _sceneLoadService;
        private void Awake()
        {
            CreateGame();
            DontDestroyOnLoad(this);
        }
        private void CreateGame()
        {
            StartCoroutine(_sceneLoadService.LoadGame(Init, "MainScene", 1f));
        }
        private void Init()
        {
            _inputService = new InputService();
            _game = new Game(PLAYER_PATH,_inputService);
        }
    }
}