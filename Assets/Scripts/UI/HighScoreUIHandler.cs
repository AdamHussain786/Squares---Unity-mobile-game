using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreUIHandler : MonoBehaviour
{
    [Header("HighScores")]
    [SerializeField]
    private TextMeshProUGUI h_Tutorial;
    [SerializeField]
    private TextMeshProUGUI h_Level1;
    [SerializeField]
    private TextMeshProUGUI h_Level2;
    [SerializeField]
    private TextMeshProUGUI h_Level3;
    [SerializeField]
    private TextMeshProUGUI h_Level4;
    [SerializeField]
    private TextMeshProUGUI h_Level5;

    [Header("Attempts")]
    [SerializeField]
    private TextMeshProUGUI a_Tutorial;
    [SerializeField]
    private TextMeshProUGUI a_Level1;
    [SerializeField]
    private TextMeshProUGUI a_Level2;
    [SerializeField]
    private TextMeshProUGUI a_Level3;
    [SerializeField]
    private TextMeshProUGUI a_Level4;
    [SerializeField]
    private TextMeshProUGUI a_Level5;

    private Player player;
    private GameMaster gm;
    private SaveManager saveManager;

    void Awake()
    {
        saveManager = GameObject.Find("GM").GetComponent<SaveManager>();
    }

    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        saveManager.LoadPlayer();

        // Highscores
        h_Tutorial.text = "High-Score: " + player.h_tutorial.ToString("F2") + "s";
        h_Level1.text = "High-Score: " +  player.h_level1.ToString("F2") + "s";
        h_Level2.text = "High-Score: " +  player.h_level2.ToString("F2") + "s";
        h_Level3.text = "High-Score: " +  player.h_level3.ToString("F2") + "s";
        h_Level4.text = "High-Score: " +  player.h_level4.ToString("F2") + "s";

        // Attempts
        a_Tutorial.text = "Attempts: " + player.a_tutorial.ToString();
        a_Level1.text = "Attempts: " + player.a_level1.ToString();
        a_Level2.text = "Attempts: " + player.a_level2.ToString();
        a_Level3.text = "Attempts: " + player.a_level3.ToString();
        a_Level4.text = "Attempts: " + player.a_level4.ToString();
    }

}
