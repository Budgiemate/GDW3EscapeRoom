using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pButton;
    [SerializeField] private GameObject lButton;
    [SerializeField] private GameObject aButton;
    [SerializeField] private GameObject yButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private Image fadeImage;

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

    public void YButton()
    {
        FadeAndLoad("Game", 2);
    }

    public void LoadCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void FadeAndLoad(string sceneName, float duration)
    {
        StartCoroutine(FadeTransition(sceneName, duration));
    }

    //Plays a fade in effect and changes the scene
    IEnumerator FadeTransition(string sceneName, float duration)
    {
        float time = 0;
        Color color = fadeImage.color;
        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = time / duration;

            fadeImage.color = color;

            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    //Plays a fade out effect when the new scene is loaded
    IEnumerator FadeOut()
    {
        float time = 0;
        Color color = fadeImage.color;
        while (time < 1)
        {
            time += Time.deltaTime;

            color.a = 1f - (time / 1f);

            fadeImage.color = color;

            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(FadeOut());
    }
}
