using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoadService : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    public static Action _onSceneLoaded;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public IEnumerator LoadGame(Action callback, string sceneName, float t)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        
        while (operation.progress < 0.9f || progressBar.value < 0.9f )
        {
            if(operation.progress < 0.9f){ progressBar.value = Mathf.Clamp01(operation.progress / 0.9f);yield return null;}
            else if (progressBar.value < 0.9f){progressBar.value += 0.1f;yield return null;}
        }
        
        yield return new WaitForSeconds(t);
        operation.allowSceneActivation = true;
        EndingSceneLoading(callback);
    }
    private void EndingSceneLoading(Action callback)
    {
        callback?.Invoke();
        _onSceneLoaded?.Invoke();
        this.gameObject.SetActive(false);
    }
}