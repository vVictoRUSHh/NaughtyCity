using UnityEngine;

public class InputService : IInputService
{
    public Vector2 _playerInput
    {
        get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));}
    }

    public bool _isMovementLocked { get; set; }
}