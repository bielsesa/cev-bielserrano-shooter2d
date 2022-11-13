using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject controlsUI;

    private void Start()
    {
        controlsUI.SetActive(false);
    }
    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }
    public void ShowControls()
    {
        mainUI.SetActive(false);
        controlsUI.SetActive(true);
    }    
    public void HideControls()
    {
        mainUI.SetActive(true);
        controlsUI.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
