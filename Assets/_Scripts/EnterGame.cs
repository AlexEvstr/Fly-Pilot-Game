using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private GameObject _pause;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void GoBtn()
    {
        _tutorial.SetActive(false);
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeBtn()
    {
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
