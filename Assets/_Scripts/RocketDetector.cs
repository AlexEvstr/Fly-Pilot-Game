using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDetector : MonoBehaviour
{
    [SerializeField] private GameObject _enemySplash;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _enemyDestroy;

    private void Start()
    {
        _audioSource = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _audioSource.PlayOneShot(_enemyDestroy);
            Destroy(collision.gameObject);
            GameObject enemySplash = Instantiate(_enemySplash);
            enemySplash.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(enemySplash, 0.5f);
            Destroy(gameObject);
        }
    }
}
