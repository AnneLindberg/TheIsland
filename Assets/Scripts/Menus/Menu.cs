using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        continueButton.interactable = PlayerPrefs.HasKey("Save");
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnNewGameButton()
    {
        PlayerPrefs.DeleteKey("Save");
        SceneManager.LoadScene("Game");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}