using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _delay = 5.0f;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawn = false;
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 spawn_pos = new Vector3(Random.Range(-8f, 8f), 8, 0);
            GameObject _newEnemy = Instantiate(_enemyPrefab, spawn_pos, Quaternion.identity);
            _newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_delay);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawn = true;
    }
}
