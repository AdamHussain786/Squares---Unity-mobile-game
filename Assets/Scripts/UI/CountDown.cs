using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float timeStart;
    public TextMeshProUGUI textBox;
    bool timerActive = true;

    [HideInInspector]
    public int coinTaker = 0;
    [HideInInspector]
    public float scoreAchieved;
    private GameMaster gm;
    private HighScoreManager highScoreManager;


    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        highScoreManager = GameObject.Find("GM").GetComponent<HighScoreManager>();

    }

    void Update()
    {
        if(timerActive)
        {
            scoreAchieved = (timeStart += Time.deltaTime);
            textBox.text = timeStart.ToString("F2");
        }
    }

    public void EnableTimer()
    {
        timerActive = true;
    }

    public void DisableTimer()
    {
        timerActive = false;
        Debug.Log("Score of: " + scoreAchieved + " achieved");
        // Go to gamemaster for high score crunching
        if(gm != null)
        {
            Win_UI winUI = GameObject.Find("WinUI").GetComponent<Win_UI>();
            highScoreManager.HighScoreHandler(scoreAchieved);
            winUI.ShowScoreAchievedOnUI(scoreAchieved, highScoreManager.earnedAmount, coinTaker);
        }
        
    }
}
