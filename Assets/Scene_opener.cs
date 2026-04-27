using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_opener : MonoBehaviour
{

    public void OpenScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }



}
