using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _factorText;
    public static float Factor;
    private float _score;

    private void Start()
    {
        _score = PlayerPrefs.GetInt("score", 0);
        Factor = 1;
        StartCoroutine(CheckTutorial());
    }

    private IEnumerator CheckTutorial()
    {
        while (_tutorial.activeInHierarchy)
        {
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(IncreaseScore());
    }

    private IEnumerator IncreaseScore()
    {
        while(true)
        {
            _score += 1 * Factor;
            _scoreText.text = $"Score: \n {(int)_score}";
            _factorText.text = $"x{Factor}";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
