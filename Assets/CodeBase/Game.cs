namespace CodeBase
{
    public class Game
    {
        private PlayerFactory _playerFactory;

        public Game(string playerPath,IInputService inputService)
        {
            _playerFactory = new PlayerFactory(playerPath,inputService);
        }
    }
}