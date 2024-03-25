using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _skins;
    [SerializeField] private GameObject _settings;

    public void StartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
    }

    public void CloseSettings()
    {
        _settings.SetActive(false);
    }

    public void OpenSkins()
    {
        _skins.SetActive(true);
    }

    public void CloseSkins()
    {
        _skins.SetActive(false);
    }
}
