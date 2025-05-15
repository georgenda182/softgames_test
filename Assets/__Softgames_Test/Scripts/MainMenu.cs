using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        _loadingScreen.SetActive(true);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
