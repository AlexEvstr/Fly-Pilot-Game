using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _tutorial;

    private void Start()
    {
        StartCoroutine(CheckTutorial());
    }

    private IEnumerator CheckTutorial()
    {
        while (_tutorial.activeInHierarchy)
        {
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            GameObject newCoin = Instantiate(_enemy);
            newCoin.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 7);
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        }
    }
}
