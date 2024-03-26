using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject _on;
    [SerializeField] private GameObject _off;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("audio", 1);
        if (AudioListener.volume == 1)
        {
            OnMusic();
        }
        else
        {
            OffMusic();
        }
    }

    public void OffMusic()
    {
        _off.SetActive(true);
        _on.SetActive(false);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("audio", AudioListener.volume);
    }

    public void OnMusic()
    {
        _on.SetActive(true);
        _off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("audio", AudioListener.volume);
    }
}
