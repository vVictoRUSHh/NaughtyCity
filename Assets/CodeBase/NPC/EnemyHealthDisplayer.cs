using System;
using CodeBase.NPC;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplayer : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private EnemyHealth _enemyHealth;
    private Camera _camera;

    private void DisplayHealth()
    {
        _hpSlider.value = (float)_enemyHealth.Health / 100;
        print($"hp in slider {_enemyHealth.Health / 100}");
    }

    private void Start()
    {
        Invoke("InitializationOfCamera",2f);
    }

    private void Update()
    {
        LookAtPlayer();
        DisplayHealth();
    }

    private void LookAtPlayer()
    {
        if(_camera!=null)_hpSlider.transform.LookAt(_camera.transform);
    }
    private void InitializationOfCamera()
    {
        _camera = Camera.main;
    }
}
