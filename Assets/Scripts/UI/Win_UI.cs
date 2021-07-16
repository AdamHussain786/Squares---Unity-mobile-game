using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win_UI : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI earnedAmount;
    GameMaster gm;
    public int coinAmount;
    public bool achievedHighScore = false;

    void Awake()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
    }

    public void ShowScoreAchievedOnUI(float scoreAchieved, int earnedMoney, int coinAmount)
    {
        if (achievedHighScore)
        {
            timeDisplay.text = ("New HighScore!: " + scoreAchieved.ToString("F2")) + "s";
            achievedHighScore = false;
        }
        else
        {
            timeDisplay.text = ("Time: " + scoreAchieved.ToString("F2")) + "s";
        }

        int totalAmount = earnedMoney + gm.coinCache;
        StartCoroutine(iterationDelay(totalAmount));
    }

    IEnumerator iterationDelay(int total)
    {
        int iterations = 0;

        while (iterations < total)
        {
            iterations++;
            earnedAmount.text = iterations.ToString();
            AudioManager.instance.PlaySound("Iterations");
            yield return new WaitForSecondsRealtime(0.1f);

            if(Input.touchCount > 0)
            {
                iterations = total;
                earnedAmount.text = iterations.ToString();
                AudioManager.instance.PlaySound("Iterations");
            }

        }
    }

}
