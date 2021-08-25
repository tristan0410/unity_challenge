using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnME;

    void Start()
    {
        _spawnME = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnME == null)
        {
            Debug.LogError("Component Spawn Manager is NULL.");
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(GameObject.FindWithTag("Boom"), 3f);
            _spawnME.StartSpawn();
            Destroy(this.gameObject, 0.5f);

        }
    }
}
