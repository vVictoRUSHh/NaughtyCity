using UnityEngine;
namespace CodeBase
{
    public class Bootstrap : MonoBehaviour
    {
        public Game _game;
        public const string PLAYER_PATH = "Player/FPS_PLAYER";
        public InputService _inputService;
        public SceneLoadService _sceneLoadService;
        private void Awake()
        {
            _sceneLoadService = new SceneLoadService();
            _sceneLoadService.LoadSceneAsync("MainScene");
            Invoke("InitializeGame",1f);
            DontDestroyOnLoad(this);
        }
        private void InitializeGame()
        {
            _inputService = new InputService();
            _game = new Game(PLAYER_PATH,_inputService);
        }
    }
}