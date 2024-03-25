using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDetector : MonoBehaviour
{
    [SerializeField] private GameObject _enemySplash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            GameObject enemySplash = Instantiate(_enemySplash);
            enemySplash.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(enemySplash, 0.5f);
            Destroy(gameObject);
        }
    }
}
