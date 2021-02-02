using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void Controls()
    {
        SceneManager.LoadSceneAsync("Controls");
    }
}