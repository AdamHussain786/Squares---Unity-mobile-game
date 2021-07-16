using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    

    [SerializeField]
    private float thrust = 12f;
    [SerializeField]
    private float restartDelay_Sec = 1;

    private GameMaster gm;
    private SaveManager saveManager;
    private Drag_Shoot DG;

    [HideInInspector]
    public SpriteRenderer rend;

    public int currency = 0;
    
    [HideInInspector]
    public string currentColour;
    [HideInInspector]
    public List<string> boughtItems;

    private Button load;

    [HideInInspector]
    public float highScore = 0;
    private BoxCollider2D boxCollider2D;

    //Upgradeable And Need To Be Saved
    public int moneyMultiplier = 100;
    public int swipes = 2;
    

    [SerializeField]
    private LayerMask platformLayerMask;

    // HighScore Variables
    #region
    [HideInInspector]
    public float h_tutorial = 0;
    [HideInInspector]
    public float h_level1 = 0;
    [HideInInspector]
    public float h_level2 = 0;
    [HideInInspector]
    public float h_level3 = 0;
    [HideInInspector]
    public float h_level4 = 0;
    [HideInInspector]
    public float h_level5 = 0;

    #endregion

    // Attempt Variables
    #region
    [HideInInspector]
    public float a_tutorial = 0;
    [HideInInspector]
    public float a_level1 = 0;
    [HideInInspector]
    public float a_level2 = 0;
    [HideInInspector]
    public float a_level3 = 0;
    [HideInInspector]
    public float a_level4 = 0;
    [HideInInspector]
    public float a_level5 = 0;
    #endregion


    void Start()
    {
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        saveManager = GameObject.Find("GM").GetComponent<SaveManager>();
        DG = GetComponent<Drag_Shoot>();
        rend = GetComponent<SpriteRenderer>();

        if(gm.currencyText != null)
        {
            gm.currencyText.text = currency.ToString();
        }
        boxCollider2D = GetComponent<BoxCollider2D>();
     

    }

    public bool isGrounded()
    {
        float extraHeightTest = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightTest, platformLayerMask);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest));
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    #region
    
    #endregion
}
