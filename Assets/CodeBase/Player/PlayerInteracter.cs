using CodeBase;
using CodeBase.Patterns.State.NPC;
using InfimaGames.LowPolyShooterPack;
using TMPro;
using UnityEngine;
public class PlayerInteracter : MonoBehaviour
{
    
    [SerializeField] private LayerMask _interactableLayerMask;
    [SerializeField] private Camera _camera;
    [Range(0, 100f)] [SerializeField] private float _rayDistance;
    public TMP_Text _text;
    private Movement _playerMovement;
    private bool _canInteract;
    public int _dialogRepliceCount;
    
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        CheckingForInteraction();
    }

    private void CheckingForInteraction()
    {
        if(!_playerMovement._inputService._isMovementLocked)GetRayHit();
        TryToInteract(_canInteract,Input.GetKeyDown(KeyCode.E));
    }
    private void Init()
    {
        _camera = Camera.main;
        _playerMovement = GetComponent<Movement>();
    }

    private void TryToInteract(bool canInteract,bool interactButton)
    {
        if (canInteract && interactButton)
        {
            CallingInteractMethod(GetRayHit());
        }
    }

    private RaycastHit GetRayHit()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, _interactableLayerMask))
        {
            _canInteract = true;
            _text.text = "Press \"E\" to interact";
                return hit;
        }
        _text.text = "";
            _canInteract = false;
        return new RaycastHit();
    }

    private void  CallingInteractMethod(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent(out IInteractable interactable))
            interactable.Interact();
    }
    
}