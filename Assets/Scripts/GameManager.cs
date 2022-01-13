using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int best;
    public int score;
    public int currentStage = 0;

    public static GameManager singleton;

    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)//oyun yeni baþladý
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);
        best = PlayerPrefs.GetInt("Highscore");
    }
    
    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);

        Debug.Log("Next Level");
    }

    public void RestartLevel()
    {
        Debug.Log("Game Over");

        //Show ads
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();

        //Reload stage

        FindObjectOfType<HelixController>().LoadStage(currentStage);

        
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Highscore", best);
        }
            
    }
}
