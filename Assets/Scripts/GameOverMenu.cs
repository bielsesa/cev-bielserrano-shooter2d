using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
