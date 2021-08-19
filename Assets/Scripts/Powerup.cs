using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupSpeed = 3f;
    [SerializeField]
    private int _PowerupID;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerupSpeed * Time.deltaTime);

        if(transform.position.y <= -7.45f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {                
                switch(_PowerupID)
                {
                    case 0:
                        player.TripleShotEnable();
                        Debug.Log("You get Triple shot powerup.");
                        break;
                    case 1:
                        player.SpeedBoostEnable();
                        Debug.Log("You get speed powerup.");
                        break;
                    case 2:
                        //shield powerup
                        Debug.Log("You get shield powerup.");
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
