using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
