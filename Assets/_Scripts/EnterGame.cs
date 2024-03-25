using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;

    public void GoBtn()
    {
        _tutorial.SetActive(false);
    }
}
