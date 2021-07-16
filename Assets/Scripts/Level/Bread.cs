using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{

    private Player player;

    private GameMaster gm;

    private CountDown timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        timer = GameObject.Find("Timer_Overlay").GetComponent<CountDown>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && gm.canHarmPlayer == true && player!=null)
        {
            gm.DisablePlayer();
            gm.WinGame();

            //Disable Timer and call the highscore function on it
            timer.DisableTimer();
        }
    }
}
