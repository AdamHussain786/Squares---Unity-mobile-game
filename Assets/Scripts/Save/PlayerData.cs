using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PlayerData
{

    public int currency;
    public string currentColour;

    public List<string> boughtItems;

    public int moneyMultiplier;
    public int swipes;

    public float h_tutorial;
    public float h_level1;
    public float h_level2;
    public float h_level3;
    public float h_level4;
    public float h_level5;

    public float a_tutorial;
    public float a_level1;
    public float a_level2;
    public float a_level3;
    public float a_level4;
    public float a_level5;

    public PlayerData(Player player)
    {
        boughtItems = player.boughtItems;
        //string[] boughtColours = boughtItems.ToArray();
        currency = player.currency;
        currentColour = player.currentColour;

        moneyMultiplier = player.moneyMultiplier;
        swipes = player.swipes;


        h_tutorial = player.h_tutorial;  h_level1 = player.h_level1;

              h_level2 = player.h_level2;
        h_level3 = player.h_level3;
        h_level4 = player.h_level4;
        h_level5 = player.h_level5;

        a_tutorial = player.a_tutorial;
        a_level1 = player.a_level1;
        a_level2 = player.a_level2;
        a_level3 = player.a_level3;
        a_level4 = player.a_level4;
        a_level5 = player.a_level5;
    }

    
  


}
