using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanal;
    public GameObject instructionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Awakening");
    }
    public void Tutorial()
    {
        instructionsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
