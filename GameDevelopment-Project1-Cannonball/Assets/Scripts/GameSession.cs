using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //Config parameters:
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePointsPerBlock = 10;
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] TextMeshProUGUI currentLevelDisplay;
    [SerializeField] int loseNumberOfHealth = 1;

    //State Variables:
    [SerializeField] int currentScore = 0; //This is just to provide a visualization of what our score is. It will always start at zero each game.
    [SerializeField] int startingNumberOfHealth = 3;

    // Start is called before the first frame update

    public void Awake()
    {
        destroyGameStatus();
    }

    public void destroyGameStatus()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreDisplay.text = currentScore.ToString();
        currentLevelDisplay.text = SceneManager.GetActiveScene().name.ToString();
    }

    public void AddToScore()
    {
        currentScore = currentScore + scorePointsPerBlock; //This would mean that each block is worth 10 points.
    }

    public void LoseHealthInLevel() //TO-DO: Develop Health Code
    {
        startingNumberOfHealth = startingNumberOfHealth - loseNumberOfHealth; //This would mean that each death means lose 1 life.
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

        scoreDisplay.text = currentScore.ToString();
        currentLevelDisplay.text = SceneManager.GetActiveScene().name.ToString();
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

}
