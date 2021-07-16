using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Will handle all highscore and attempt data
public class HighScoreManager : MonoBehaviour
{
    LevelManager lm;

    [HideInInspector]
    public Player player;

    private float HighScoreStore;
    private float AttemptStore;
    SaveManager saveManager;
    public Win_UI winUI;
    [HideInInspector]
    public int earnedAmount;

    void Awake()
    {
        //Exist on gm so on awake needed
        saveManager = GetComponent<SaveManager>();
        lm = GetComponent<LevelManager>();
    }


    public void HighScoreHandler(float scoreAchieved)
    {
        Debug.Log("Calculating High Score");

        lm.GetCurrentSceneIndex();

        ApplyHighScore(scoreAchieved);

        //Take scoreAchieved from the countdown script. Compare that with the current high score. If bigger it will make scoreAchived == HighScore.

        //Add Money
        CalculateCurrencyWithScore(scoreAchieved);
    }

    void ApplyHighScore(float scoreAchieved)
    {
        if (player == null)
            return;

        switch (lm.currentSceneIndex)
        {
            case 1:
                CalculateHighScore(scoreAchieved, player.h_tutorial);
                CalculateAttempts(player.a_tutorial);
                player.h_tutorial = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for tutorial" + player.h_tutorial);
                saveManager.SavePlayer();
                break;
            case 2:
                CalculateHighScore(scoreAchieved, player.h_level1);
                CalculateAttempts(player.a_level1);
                player.h_level1 = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for level 1" + player.h_level1);
                saveManager.SavePlayer();
                break;
            case 3:
                CalculateHighScore(scoreAchieved, player.h_level2);
                CalculateAttempts(player.a_level2);
                player.h_level2 = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for level 2" + player.h_level2);
                saveManager.SavePlayer();
                break;
            case 4:
                CalculateHighScore(scoreAchieved, player.h_level3);
                CalculateAttempts(player.a_level3);
                player.h_level3 = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for level 3" + player.h_level3);
                saveManager.SavePlayer();
                break;
            case 5:
                CalculateHighScore(scoreAchieved, player.h_level4);
                CalculateAttempts(player.a_level4);
                player.h_level4 = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for level 4" + player.h_level4);
                saveManager.SavePlayer();
                break;
            case 6:
                CalculateHighScore(scoreAchieved, player.h_level5);
                CalculateAttempts(player.a_level5);
                player.h_level5 = HighScoreStore;
                Debug.Log("ApplyHighScore Func returned for level 5" + player.h_level5);
                saveManager.SavePlayer();
                break;

        }
    }

    public void ApplyAttempts()
    {
        if (player == null)
            return;

        switch (lm.currentSceneIndex)
        {
            case 1:

                CalculateAttempts(player.a_tutorial);
                player.a_tutorial = AttemptStore;
                Debug.Log("Attempt Func returned for tutorial" + player.a_tutorial);
                saveManager.SavePlayer();
                break;
            case 2:

                CalculateAttempts(player.a_level1);
                player.a_level1 = AttemptStore;
                Debug.Log("Attempt Func returned for level 1" + player.a_level1);
                saveManager.SavePlayer();
                break;
            case 3:

                CalculateAttempts(player.a_level2);
                player.a_level2 = AttemptStore;
                Debug.Log("Attempt Func returned for level 2" + player.a_level2);
                saveManager.SavePlayer();
                break;
            case 4:

                CalculateAttempts(player.a_level3);
                player.a_level3 = AttemptStore;
                Debug.Log("Attempt Func returned for level 3" + player.a_level3);
                saveManager.SavePlayer();
                break;
            case 5:
                CalculateAttempts(player.a_level4);
                player.a_level4 = AttemptStore;
                Debug.Log("Attempt Func returned for level 4" + player.a_level4);
                saveManager.SavePlayer();
                break;
            case 6:
                CalculateAttempts(player.a_level5);
                player.a_level5 = AttemptStore;
                Debug.Log("Attempt Func returned for level 5" + player.a_level5);
                saveManager.SavePlayer();
                break;

        }
    }

    public void CalculateHighScore(float scoreAchieved, float highScore)
    {
        if (highScore == 0f)
        {
            highScore = scoreAchieved;
            HighScoreStore = highScore;

            Debug.Log("Player had no previous high score. He achieved: " + HighScoreStore);
        }
        else if (scoreAchieved < highScore)
        {
            highScore = scoreAchieved;
            HighScoreStore = highScore;
            winUI.GetComponent<Win_UI>().achievedHighScore = true;

            Debug.Log("Player beat previous score with: " + HighScoreStore);

        }
        else
        {
            HighScoreStore = highScore;
            Debug.Log("Player Did Not Beat His High Score");
            return;
        }
    }

    public void CalculateAttempts(float attempt)
    {
        attempt += 1;
        AttemptStore = attempt;
    }


    void CalculateCurrencyWithScore(float scoreAchieved)
    {
        if (player == null)
            return;

        // Algorithm to calculate
        earnedAmount = (int)Mathf.Round(player.moneyMultiplier / scoreAchieved);
        Debug.Log("Player earned: " + earnedAmount);
        player.currency += earnedAmount;
        Debug.Log("Player now has: " + player.currency);
        saveManager.SavePlayer();
    }

}
