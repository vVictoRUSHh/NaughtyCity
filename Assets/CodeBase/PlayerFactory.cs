using UnityEngine;

public class PlayerFactory
{
    public PlayerFactory(string gameobjectPath,IInputService inputService)
    {
       GameObject _prefab = Resources.Load<GameObject>(gameobjectPath);
       GameObject _playerObj = Object.Instantiate(_prefab);
       if (_playerObj.TryGetComponent(out FirstPersonController firstPersonController))
       {
           firstPersonController._inputService = inputService;
       }
       else
       {
           Debug.Log("Ничего не нашел анлак");
       }
    }
}