using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pButton;
    [SerializeField] private GameObject lButton;
    [SerializeField] private GameObject aButton;
    [SerializeField] private GameObject yButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject journal;

    [SerializeField] private KeyCode openJournalKey;
    [SerializeField] private KeyCode closeJournalKey;

    public void LoadTitleScreen()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1.0f;
    }

    public void LoadPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PButton()
    {
        pButton.SetActive(false);
        lButton.SetActive(true);
    }

    public void LButton()
    {
        lButton.SetActive(false);
        aButton.SetActive(true);
    }

    public void AButton()
    {
        aButton.SetActive(false);
        yButton.SetActive(true);
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(openJournalKey) && Time.timeScale != 0)
        {
            journal.SetActive(true);
        }

        if (Input.GetKeyDown(closeJournalKey) && Time.timeScale != 0)
        {
            journal.SetActive(false);
        }
    }
}
