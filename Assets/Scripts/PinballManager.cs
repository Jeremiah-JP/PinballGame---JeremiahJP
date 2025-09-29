using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinballManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int score = 0;
    int highScore = 0;

    [SerializeField] GameObject ballObj;
    Vector3 ballStartPos;

    void Start()
    {
        ballStartPos = ballObj.transform.position;

        highScore = PlayerPrefs.GetInt("HighScore", 0);

      
        score = 0;

        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;          
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        UpdateScoreText();
    }


    void UpdateScoreText()
        {
            scoreText.text = "Score: " + score + "  |  High Score: " + highScore;
        }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
         
            SceneManager.LoadScene("Week2");
        }
    }
}