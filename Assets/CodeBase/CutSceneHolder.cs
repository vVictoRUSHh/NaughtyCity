using CodeBase.Patterns.EventBus;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneHolder : MonoBehaviour
{
    [SerializeField] private PlayableDirector _startCutScene;

    private void OnEnable()
    {
        EventBus.Instance.onSceneLoaded += PlayStartCutScene;
    }

    private void OnDisable()
    {
        EventBus.Instance.onSceneLoaded -= PlayStartCutScene;
    }

    public void PlayStartCutScene()
    {
        _startCutScene.Play();
    }
}