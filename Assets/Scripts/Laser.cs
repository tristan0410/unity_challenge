using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _laserSpeed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
        if(transform.position.y >= 9.1)
        {
            if(transform.parent != null) //to check if the object has parent or not
            {
                Destroy(transform.parent.gameObject);
            }
            
            Destroy(this.gameObject);
        }
    }
}
