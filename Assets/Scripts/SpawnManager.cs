using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _delay = 5.0f;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] Powerup_Prefab;
    private bool _stopSpawn = false;
    void Start()
    {
        StartCoroutine(spawnEnemyRoutine());
        StartCoroutine(spawnPowerupRoutine());
    }

    IEnumerator spawnEnemyRoutine()
    {
        while (_stopSpawn == false)
        {
            Vector3 spawn_pos = new Vector3(Random.Range(-8f, 8f), 8, 0);
            GameObject _newEnemy = Instantiate(_enemyPrefab, spawn_pos, Quaternion.identity);
            _newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_delay);
            //Debug.Log("The random range is " + spawn_pos);
        }
    }

    IEnumerator spawnPowerupRoutine()
    {
        while (_stopSpawn == false)
        {
            int powerup_delay = Random.Range(3, 8);
            Vector3 powerup_pos = new Vector3(Random.Range(-8f,8f), 8.13f, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(Powerup_Prefab[randomPowerup], powerup_pos, Quaternion.identity);
            yield return new WaitForSeconds(powerup_delay);
            //Debug.Log("Triple powerup delay is " + powerup_delay);
            //Debug.Log("The random range is " + powerup_pos);
        }
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawn = true;
    }
}
