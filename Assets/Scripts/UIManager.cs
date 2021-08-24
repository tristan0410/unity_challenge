using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOver_text;
    [SerializeField]
    private Text _restart_text;
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Image _livesIMG;
    private GameManager _over;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOver_text.gameObject.SetActive(false);
        _over = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_over == null)
        {
            Debug.LogError("Player is NULL.");
        }
    }

    public void update_score(int score)
    {
        _scoreText.text = "Score: " + score.ToString(); //ToString() will change it into string 
    }

    public void update_lives(int lives)
    {
        _livesIMG.sprite = _lives[lives];

        if (lives == 0)
        {
            _gameOver_text.gameObject.SetActive(true);
            _restart_text.gameObject.SetActive(true);
            _over.GameOver();

        }
    }
}
