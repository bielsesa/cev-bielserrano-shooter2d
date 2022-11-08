using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject BtnContinue;

    private void Start()
    {
        //BtnContinue.GetComponent<Button>().interactable = false;
    }
    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }
    public void ShowControls()
    {
        // TODO
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
