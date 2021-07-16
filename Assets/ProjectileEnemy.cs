using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField]
    private float damage = 1000;

    private PlayerHealth playerHealth;
    private GameMaster gm;
    public ParticleSystem dustPS;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        dustPS.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player") && gm.canHarmPlayer == true)
        {

            Debug.Log("Hit Player");
            Damage();
            //TODO Play effects

            Destroy(gameObject);

        }
        else if(!collision.collider.CompareTag("EnemyShooter"))
        {
            // TODO Play Effects
            Destroy(gameObject);
        }
    }

    void Damage()
    {
        playerHealth.playerHealth = playerHealth.playerHealth - damage;
        playerHealth.UpdateHealth();
    }
}
