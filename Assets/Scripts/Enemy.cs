using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _enemySpeed = 6f;
    void Start()
    {
        transform.position = new Vector3(0, 8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if(transform.position.y <= -3.8)
        {
            float random_X = Random.Range(-8f, 8f); //chooses a range of random number
            transform.position = new Vector3(random_X, 8, 0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Hit = " + other.transform.name);
    }
}
