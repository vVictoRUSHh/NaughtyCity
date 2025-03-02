using CodeBase.Patterns.EventBus;
using UnityEngine;
using UnityEngine.UI;
public class NpcMarker : MonoBehaviour
{
    public Image _marker;
    [SerializeField] private Camera _camera;
    public float _floatSpeed = 1f; // Скорость колебания
    public float _floatAmplitude = 10f; // Амплитуда колебания
    private Vector3 _startPosition;

    private void OnEnable()
    {
        EventBus.Instance.onSceneLoaded += Init;
    }

    private void OnDisable()
    {
        EventBus.Instance.onSceneLoaded -= Init;
    }

    private void Start()
    {
        _startPosition = _marker.transform.localPosition;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        if(_camera!=null)_marker.transform.LookAt(_camera.transform);
        float offset = Mathf.Sin(Time.time * _floatSpeed) * _floatAmplitude;
        _marker.transform.localPosition = _startPosition + new Vector3(0, offset, 0);
    }

    private void Init()
    {
        _camera = Camera.main;
    }
}
