using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    [Header("Icons")]
    public Sprite red;
    public Sprite blue;
    public Sprite purple;
    public Sprite pink;
    public Sprite grey;
    public Sprite yellow;
    public Sprite green;

    [Header("Death Particles")]
    public GameObject red_gm;
    public GameObject blue_gm;
    public GameObject purple_gm;
    public GameObject pink_gm;
    public GameObject grey_gm;
    public GameObject yellow_gm;
    public GameObject green_gm;

    [Header("Upgrades")]
    public Sprite swipes;
    public Sprite moneyMultiplier;

    [Header("CoinPopup")]
    public Transform pfDamagePopup;

    [Header("TextElements")]
    public TextMeshProUGUI swipesText;
    public TextMeshProUGUI moneyMultiplierText;
}
