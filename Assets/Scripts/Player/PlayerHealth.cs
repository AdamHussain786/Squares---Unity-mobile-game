using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100;
    public GameObject deathParticles;
    public float explosionRadius = 100f;
    GameMaster gm;
    HighScoreManager highScoreManager;

    void Start() 
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        highScoreManager = GameObject.Find("GM").GetComponent<HighScoreManager>();
    }

    public void UpdateHealth()
    {
        if(playerHealth <= 0)
        {
            Debug.Log("PLAYER DIED!!!");
            gm.DisablePlayer();
            int i = 0;
            int amount = 9;
            while(i < amount)
            {
                GameObject particles =  Instantiate(deathParticles, transform.position, Quaternion.identity);
                Rigidbody rb = particles.GetComponent<Rigidbody>();

                rb.AddExplosionForce(500f, transform.position, explosionRadius);
                i++;

                Destroy(particles, 2);
            }

            StartCoroutine(restartDelay());
            highScoreManager.ApplyAttempts();
            AudioManager.instance.PlaySound("Death");
            //AudioManager.instance.StopSound("Theme");
            gm.EndGame();
            

        }
    }

    private IEnumerator restartDelay()
    {
        yield return new WaitForSeconds(1);
        gm.ResetLevel();
    }
    
}
