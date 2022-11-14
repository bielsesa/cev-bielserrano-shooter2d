using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinMenu : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
