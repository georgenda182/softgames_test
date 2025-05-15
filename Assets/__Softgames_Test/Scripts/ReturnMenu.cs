using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("_MainMenu");
    }
}
