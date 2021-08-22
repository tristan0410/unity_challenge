using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }
    public void update_score(int score)
    {
       _scoreText.text = "Score: " + score.ToString(); //ToString() will change it into string 
    }
}
