using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private float _speed = 2.0f;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
    }
}
