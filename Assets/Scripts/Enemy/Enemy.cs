using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float damage = 1000;

    private PlayerHealth playerHealth;
    private GameMaster gm;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && gm.canHarmPlayer == true)
        {
            
            Debug.Log("Hit Player");
            Damage();
            playerHealth.UpdateHealth();
        }
    }

    void Damage()
    {
        playerHealth.playerHealth = playerHealth.playerHealth - damage;
    }
}
