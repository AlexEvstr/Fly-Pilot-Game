using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShoot : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private GameObject _plane;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _rocketShot;

    public void ShootRocket()
    {
        _audioSource.PlayOneShot(_rocketShot);
        GameObject newRocket = Instantiate(_rocket);
        newRocket.transform.position = new Vector3(_plane.transform.position.x, _plane.transform.position.y);
        Destroy(newRocket, 3f);
    }
}
