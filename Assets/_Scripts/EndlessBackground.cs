using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
        if (transform.position.y <= -19.8f)
        {
            transform.position = new Vector2(0, 19.8f);
        }
    }
}