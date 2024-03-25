using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 3.0f;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
    }
}
