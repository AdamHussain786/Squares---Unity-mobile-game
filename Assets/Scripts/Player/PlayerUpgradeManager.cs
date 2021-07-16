using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{

    SaveManager saveManager;
    Player player; 
    PlayerHealth playerHealth;
    GameMaster gm;

    void Start()
    {
        saveManager = GameObject.Find("GM").GetComponent<SaveManager>();
        gm = GameObject.Find("GM").GetComponent<GameMaster>();
        player = gameObject.GetComponent<Player>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    public void BoughtUpgrade(Item.ItemType itemType)
    {
        if(player == null)
            Debug.Log("Player is null");
        // Check it foreach upgrade
        if(Item.GetName(itemType) == "Swipes")
        {
            
            if(player.currency >= Item.GetCost(itemType))
            {
                AudioManager.instance.PlaySound("Rich");
                player.currency -= Item.GetCost(itemType);
                player.swipes++;
                // Update How Many Swipes U Bought Text
                UI_Upgrades uiUpgrades = GameObject.Find("UpgradeMenuCanvas").GetComponent<UI_Upgrades>();
                if (uiUpgrades != null)
                    uiUpgrades.CreateUpgrades();
                gm.UpdateNumberOfUpgradesText();
                gm.UpdateCurrencyText();
                saveManager.SavePlayer();
            }
            else
            {
                AudioManager.instance.PlaySound("Poor");
                return;
            }
            
        }
        else if (Item.GetName(itemType) == "2X")
        {
            
            if (player.currency >= Item.GetCost(itemType))
            {
                player.currency -= Item.GetCost(itemType);
                player.moneyMultiplier *= 2;
                UI_Upgrades uiUpgrades = GameObject.Find("UpgradeMenuCanvas").GetComponent<UI_Upgrades>();
                if (uiUpgrades != null)
                    uiUpgrades.CreateUpgrades();
                gm.UpdateCurrencyText();
                saveManager.SavePlayer();
            }
            else
            {
                return;
            }

        }

    }

    public void BoughtItem(Item.ItemType itemType)
    {
        //Add to list of bought items
        if (player.boughtItems.Contains(Item.GetName(itemType)))
        {
            ApplyColour(itemType);
            Debug.Log("Player tried to buy item her already has!");
            AudioManager.instance.PlaySound("Click");
        }
        else if(TrySpendBreadAmount(Item.GetCost(itemType)) && !player.boughtItems.Contains(Item.GetName(itemType)))
        {
            // Apply colour change!
            AudioManager.instance.PlaySound("Rich");
            Debug.Log("Bought item: " + itemType);
            player.boughtItems.Add(Item.GetName(itemType));
            //Update Text
            
            //Apply the new colour
            ApplyColour(itemType);
        }
        else
        {
            // Warn no funds!
            AudioManager.instance.PlaySound("Poor");
            Debug.Log("Too Poor To Buy: " + itemType);
        }
    }

    public bool TrySpendBreadAmount(int breadAmount)
    {
        if(player.currency >= breadAmount)
        {
            player.currency -= breadAmount;
            // Change the text for money!
            gm.currencyText.text = player.currency.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ApplyColour(Item.ItemType itemType)
    {
        if (player == null)
            player = gameObject.GetComponent<Player>();
            playerHealth = gameObject.GetComponent<PlayerHealth>();

        //Need Colour Index for saves!
        player.rend.color = Item.GetColour(itemType);        
        //Set the current colour here
        player.currentColour = Item.GetName(itemType);

        playerHealth.deathParticles =  Item.deathParticles(itemType);

        //Save this current colour
        if(gm != null)
        {
             saveManager.SavePlayer();
        }
       

    }
}
