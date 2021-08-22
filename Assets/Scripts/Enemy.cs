using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _enemySpeed = 6f;
    private Player _player;
    void Start()
    {
        transform.position = new Vector3(0, 8, 0);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();  //to get the component from Player.cs script
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if(transform.position.y <= -7.3)
        {
            float random_X = Random.Range(-8f, 8f); //chooses a range of random number
            transform.position = new Vector3(random_X, 8, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Hit = " + other.transform.name);

        //if(GameObject.FindWithTag("Player"))
        if(other.tag == "Player")
        {
            if(_player != null)
            {
                _player.damage();
            }
            Destroy(this.gameObject);
        }

        //if(GameObject.FindWithTag("Laser"))
        if(other.tag == "Laser")
        {
            //Destroy(GameObject.FindWithTag("Laser"));
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.addscore(10);
            }
            Destroy(this.gameObject);
        }
    }
}
