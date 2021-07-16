using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPos;
    public float timeBetweenShots = 1f;
    bool canShoot;
    [SerializeField]
    private Transform Player;
    public float speed = 500f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        canShoot = true;
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        while(canShoot)
        {
            // Vector Calculations To Calculate Player Position
            Vector2 target = Player.position;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 dir = target - myPos;
            dir.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

            // Instantiating Bullet And Firing Towards Player
            GameObject bullet = Instantiate(projectile, myPos, rotation);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(dir * speed);
            Destroy(bullet, 3);
            yield return new WaitForSeconds(timeBetweenShots);

        }
        
    }

}
