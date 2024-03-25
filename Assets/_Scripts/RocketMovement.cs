using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private float _speed = 5.0f;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
    }
}