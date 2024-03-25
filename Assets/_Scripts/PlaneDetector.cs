using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDetector : MonoBehaviour
{
    [SerializeField] private GameObject _coinSplash;
    [SerializeField] private GameObject _gameoverSplash;
    [SerializeField] private GameObject _propeller;

    [SerializeField] private GameObject _gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject coinSplash = Instantiate(_coinSplash);
            coinSplash.transform.position = collision.gameObject.transform.position;
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
    }
}
