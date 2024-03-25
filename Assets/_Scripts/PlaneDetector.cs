using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneDetector : MonoBehaviour
{
    [SerializeField] private GameObject _coinSplash;
    [SerializeField] private GameObject _gameoverSplash;
    [SerializeField] private GameObject _propeller;

    [SerializeField] private TMP_Text _timerText;

    [SerializeField] private GameObject _gameOver;

    private float _factorCoefficient = 0.1f;
    private int _timer;
    private bool flag = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Score.Factor += _factorCoefficient;
            _factorCoefficient *= 2;
            GameObject coinSplash = Instantiate(_coinSplash);
            coinSplash.transform.position = collision.gameObject.transform.position;

            if (_timer <= 5 && _timer > 0)
            {
                flag = true;
            }

            StartCoroutine(ComboTimer());
            Destroy(collision.gameObject);
            Destroy(coinSplash, 2f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemySplash = Instantiate(_gameoverSplash);
            enemySplash.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            Destroy(enemySplash, 1f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            _propeller.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            StartCoroutine(ShowGameOver());
        }
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1.15f);
        _gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator ComboTimer()
    {
        _timer = 5;
        while (_timer != 0)
        {
            if (flag == true)
            {
                flag = false;
                yield break;
            }
            _timerText.text = $"Time left: {_timer}";
            _timer -= 1;
            yield return new WaitForSeconds(1);
        }
        _timerText.text = "";
        _factorCoefficient = 0.1f;
    }
}
