using UnityEngine;

public interface IInputService
{
    public Vector2 _playerInput { get; }
    public bool _isMovementLocked { get; set;}

}