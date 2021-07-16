using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinAmount;
    CountDown cd;
    GameMaster gm;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        cd = GameObject.Find("Timer_Overlay").GetComponent<CountDown>();
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            // Give Him Currency
            if(cd != null)
            {
                cd.coinTaker += coinAmount;
            }

            if(gm != null)
            {
                gm.coinCache += coinAmount;
                gm.AddCurrency(coinAmount);
                CoinPopup.Create(transform.position, coinAmount, false);
            }
            
            AudioManager.instance.PlaySound("Coin");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            spriteRenderer.enabled = false;

        }
    }
}
