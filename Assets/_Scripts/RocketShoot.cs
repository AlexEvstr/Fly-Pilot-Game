using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShoot : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private GameObject _plane;
    
    public void ShootRocket()
    {
        GameObject newRocket = Instantiate(_rocket);
        newRocket.transform.position = new Vector3(_plane.transform.position.x, _plane.transform.position.y);
        Destroy(newRocket, 3f);
    }
}
