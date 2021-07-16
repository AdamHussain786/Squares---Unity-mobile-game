using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    GameMaster gm;
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public PlayerUpgradeManager playerUpgradeManager;

    void Awake()
    {
        gm = GetComponent<GameMaster>();
        
    }
    void Start() 
    {

        playerUpgradeManager = gm.playerUpgradeManager;
        player = gm.player;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();
        if(data != null)
        {
            player.currency = data.currency;
            player.boughtItems = data.boughtItems;

            player.moneyMultiplier = data.moneyMultiplier;
            player.swipes = data.swipes;

            //Load HighScores
            player.h_tutorial = data.h_tutorial;
            player.h_level1 = data.h_level1;
            player.h_level2 = data.h_level2;
            player.h_level3 = data.h_level3;
            player.h_level4 = data.h_level4;
            player.h_level5 = data.h_level5;

            // Load Attempts
            player.a_tutorial = data.a_tutorial;
            player.a_level1 = data.a_level1;
            player.a_level2 = data.a_level2;
            player.a_level3 = data.a_level3;
            player.a_level4 = data.a_level4;
            player.a_level5 = data.a_level5;

            //Load Colours
            if (data.currentColour != null)
            {
                player.currentColour = data.currentColour;

                //Check The Saved Colours With All Available Colours!
                CheckOurSavedColour(Item.ItemType.Red);
                CheckOurSavedColour(Item.ItemType.Blue);
                CheckOurSavedColour(Item.ItemType.Purple);
                CheckOurSavedColour(Item.ItemType.Pink);
                CheckOurSavedColour(Item.ItemType.Grey);
                CheckOurSavedColour(Item.ItemType.Yellow);
                CheckOurSavedColour(Item.ItemType.Green);
            }



            if (gm.currencyText != null)
            {
                gm.UpdateCurrencyText();
            }
        }
    }

    public void CheckOurSavedColour(Item.ItemType itemType)
    {
        //Set the current colour if it exists!
        if (player.currentColour == Item.GetName(itemType) && playerUpgradeManager!=null)
        {
            //Apply colour 
            playerUpgradeManager.ApplyColour(itemType);
        }
    }
}
