using System;
using CodeBase.NPC;
using CodeBase.Patterns.EventBus;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplayer : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private EnemyHealth _enemyHealth;
    private Camera _camera;

    private void OnEnable()
    {
       EventBus.Instance.onSceneLoaded += Init;
    }

    private void OnDisable()
    {
        EventBus.Instance.onSceneLoaded -= Init;
    }

    private void Update()
    {
        LookAtPlayer();
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        _hpSlider.value = (float)_enemyHealth.GetHealth() / 100;
    }

    private void LookAtPlayer()
    {
        if(_camera!=null)_hpSlider.transform.LookAt(_camera.transform);
    }
    private void Init()
    {
        _camera = Camera.main;
    }
}
