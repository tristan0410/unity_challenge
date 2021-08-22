using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 5.0f;
    private float _speedMult = 2.0f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _fireRate = 0.5f; //the atk speed
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _TripleShotPrefab;
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private int _score;
    private float _canFire = -1f; //To calculate fire rate with Time.time
    private SpawnManager _spawnManage; //variable given to grab SpawnManager.cs script
    private bool _TripleShotEnable = false, _ShieldEnable = false, _SpeedBoostEnable = false;
    private UIManager _UImanager; //variable given to grab UIManager.cs script

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManage = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>(); //to get access to SpawnManager.cs Script
        _UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_UImanager == null)
        {
            Debug.LogError("UI Manager is NULL.");
        }

        if (_spawnManage == null)
        {
            Debug.LogError("Spawn Manager is NULL.");
        }
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
        if (transform.position.y >= 2)
        {
            transform.position = new Vector3(transform.position.x, 2, 0);
        }
        else if (transform.position.y <= -5.8f)
        {
            transform.position = new Vector3(transform.position.x, -5.8f, 0);
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

        if (transform.position.x >= 12.8f)
        {
            transform.position = new Vector3(-12.8f, transform.position.y, 0);
        }
        else if (transform.position.x <= -12.8f)
        {
            transform.position = new Vector3(12.8f, transform.position.y, 0);
        }
    }
    void shootlaser()
    {
        _canFire = Time.time + _fireRate;

        if (_TripleShotEnable == true)
        {
            Instantiate(_TripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //Quaternion rotation means the angular rotation -> Quaternion.identity means the default rotation
            Instantiate(_laser, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        }
    }
    public void damage()
    {
        if (_ShieldEnable == true)
        {
            _ShieldEnable = false;
            _shieldVisualizer.SetActive(false);
            Debug.Log("Your shield expired.");
            return;
        }

        _lives--;
        _UImanager.update_lives(_lives);

        if (_lives < 1)
        {
            _spawnManage.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
    public void ShieldEnable()
    {
        _ShieldEnable = true;
        _shieldVisualizer.SetActive(true);
    }
    public void TripleShotEnable()
    {
        _TripleShotEnable = true;
        StartCoroutine(PowerDownRoutine());
    }
    public void SpeedBoostEnable()
    {
        _SpeedBoostEnable = true;
        _speed *= _speedMult;
        StartCoroutine(PowerDownRoutine());
    }
    IEnumerator PowerDownRoutine()
    {
        float power_time = 5f;
        if (_TripleShotEnable == true)
        {
            yield return new WaitForSeconds(power_time);
            _TripleShotEnable = false;
            Debug.Log("Your triple shot expired.");
        }
        else if (_SpeedBoostEnable == true)
        {
            yield return new WaitForSeconds(power_time);
            _speed = 5.0f;
            _SpeedBoostEnable = false;
            Debug.Log("Your speed boost expired.");
        }

    }
    public void addscore(int points) //THIS WILL HELP WITH UI ON SCORE ON THE SCREEN.
    {
        _score += points;
        _UImanager.update_score(_score);
    }

}



