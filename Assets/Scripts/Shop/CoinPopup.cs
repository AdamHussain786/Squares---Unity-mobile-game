using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPopup : MonoBehaviour
{
    // Create a Damage Popup
    public static CoinPopup Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        Transform coinPopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);

        CoinPopup coinPopup = coinPopupTransform.GetComponent<CoinPopup>();
        coinPopup.Setup(damageAmount, isCriticalHit);

        return coinPopup;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount, bool isCriticalHit)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit)
        {
            // Normal hit
            textMesh.fontSize = 10;
            textColor = Color.red;
        }
        else
        {
            // Critical hit
            textMesh.fontSize = 45;
            textColor = Color.blue;
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(.7f, 1) * 10f;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
