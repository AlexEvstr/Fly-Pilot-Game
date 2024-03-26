using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private GameObject _mark;
    [SerializeField] private int _index;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("index", 0);
        if (index == _index)
        {
            _mark.transform.SetParent(transform);
        }
    }

    public void PickSkin()
    {
        _mark.transform.SetParent(transform);
        gameObject.GetComponent<Image>().color = Color.green;
        PlayerPrefs.SetInt("index", _index);
    }

    private void Update()
    {
        if (transform.childCount == 2)
        {
            gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }
}
