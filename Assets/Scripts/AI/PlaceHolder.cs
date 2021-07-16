using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    Rigidbody2D rb;
    int power = 10;
    bool Activated;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Activated = true;
        StartCoroutine(jump());
    }

    IEnumerator jump()
    {
        while(Activated)
        {
            float x = Random.Range(-2f, 2f);
            float y = Random.Range(-2f, 2f);
            Vector2 direction = new Vector2(x, y);
            rb.AddForce(direction * power, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
        }
    }
}
