using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _fireRate = 0.5f; //the atk speed
    private float _canFire = -1f; //To calculate fire rate with Time.time
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire) //calculation for fire rate (atk speed)
        {
            shootlaser();
        }
    }

    void movement()
    {
        float horizontal_input = Input.GetAxis("Horizontal"); //To get input of left & right
        float vertical_input = Input.GetAxis("Vertical"); //To get input of up & down
        Vector3 direction = new Vector3(horizontal_input, vertical_input, 0); //New vector3 variable

        //new Vector3(1, 0, 0) * speed * real time
        //transform.Translate(Vector3.right * horizontal_input * speed * Time.deltaTime); 
        //new Vector3(0, 1, 0) * speed * real time
        //transform.Translate(Vector3.up * vertical_input * speed * Time.deltaTime);
        transform.Translate(direction * _speed * Time.deltaTime);

        //transform.position means current position
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        /*
        if (transform.position.x >= 8.1f)
        {
            transform.position = new Vector3(8.1f, transform.position.y, 0);
        }
        else if (transform.position.x <= -8.1f)
        {
            transform.position = new Vector3(-8.1f, transform.position.y, 0);
        }
        */

        if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, 0);
        }
    }

    void shootlaser()
    {
        _canFire = Time.time + _fireRate;

        //Quaternion rotation means the angular rotation -> Quaternion.identity means the default rotation
        Instantiate(_laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }
}