using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
