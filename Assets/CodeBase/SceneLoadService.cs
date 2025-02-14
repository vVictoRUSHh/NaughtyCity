using UnityEngine.SceneManagement;

public class SceneLoadService
{
    
    public  void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public  void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}