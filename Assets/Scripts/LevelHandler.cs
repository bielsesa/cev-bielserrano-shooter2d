using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        Debug.Log($"Scene {sceneName} will load in {delay} seconds");
        StartCoroutine(LoadSceneDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

    }
}
