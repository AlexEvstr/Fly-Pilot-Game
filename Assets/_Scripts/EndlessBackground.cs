using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    private float _speed = 2.0f;

    private void FixedUpdate()
    {
        if (!_tutorial.activeInHierarchy)
        {
            transform.Translate(Vector2.down * Time.deltaTime * _speed);
            if (transform.position.y <= -12f)
            {
                transform.position = new Vector2(0, 39.1f);
            }
        }
    }
}