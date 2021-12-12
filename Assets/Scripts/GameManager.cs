using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("0000");
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public void RestartGameOnPlayerDeath()
    {
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void RestartGameAfterEndOfWave()
    {
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
