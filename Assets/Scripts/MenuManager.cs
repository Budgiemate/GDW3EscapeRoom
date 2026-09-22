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

    public void LoadTitleScreen()
    {
        SceneManager.LoadSceneAsync(0);
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
}
