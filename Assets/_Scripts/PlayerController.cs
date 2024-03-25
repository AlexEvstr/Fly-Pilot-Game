using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _movementSpeed = 0.005f;
    private Touch _touch;
    private void Update()
    {
        if (Input.touchCount > 0 && !_tutorial.activeInHierarchy)
        {
            _touch = Input.GetTouch(0);
            transform.position = new Vector2(transform.position.x + _touch.deltaPosition.x * _movementSpeed, transform.position.y);
        }
    }
    [SerializeField] private GameObject _tutorial;
    private float _speed = 20.0f;
    private void FixedUpdate()
    {
        if (!_tutorial.activeInHierarchy)
            transform.Translate(Input.acceleration.x * Time.deltaTime * _speed, 0, 0);
    }
}
