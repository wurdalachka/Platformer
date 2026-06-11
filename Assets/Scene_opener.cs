using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_opener : MonoBehaviour
{
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLastScene()
    {
        string lastScene = PlayerPrefs.GetString("lastScene", "level 1");
        SceneManager.LoadScene(lastScene);
    }
}
