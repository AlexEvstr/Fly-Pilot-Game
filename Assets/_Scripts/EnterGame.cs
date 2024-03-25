using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void GoBtn()
    {
        _tutorial.SetActive(false);
        Time.timeScale = 1;
    }
}
