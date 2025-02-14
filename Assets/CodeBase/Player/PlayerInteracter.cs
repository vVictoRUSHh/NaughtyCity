using System;
using CodeBase.Patterns.State.NPC;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInteracter : MonoBehaviour
{
    public Camera _camera;
    public float rayDistance = 100f;
    public LayerMask layerMask;
    public TMP_Text _text;
    private NpcStationBehaviour _npcStationBehaviour;
    private FirstPersonController _firstPersonController;
    public int _dialogRepliceCount;
    private void Start()
    {
        _camera = Camera.main;
        _firstPersonController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if(!_firstPersonController._inputService._isMovementLocked)CanPlayerInteract();
        if (Input.GetKeyDown(KeyCode.E)) Interact();
    }
    private void Interact()
    {

        if (CanPlayerInteract())
        {
            _npcStationBehaviour._currentState.StartState();
            Debug.LogError("Я тут притаился!");
        }
    }

    private bool CanPlayerInteract()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, layerMask))
        {
            if (hit.transform.gameObject.TryGetComponent(out NpcStationBehaviour npcStationBehaviour))
            {
                _npcStationBehaviour = npcStationBehaviour;
                _text.text = "Press \"E\" to interactr";
                return true;
            }
        }
        _text.text = "";
            return false;
    }

    private void OnDrawGizmos()
    {
        if (_camera == null) return;

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(screenCenter);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray.origin, ray.direction * rayDistance);
    }
}