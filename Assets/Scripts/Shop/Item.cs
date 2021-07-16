using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item
{


   public enum ItemType
    {
        Red,
        Blue,
        Purple,
        Pink,
        Grey,
        Yellow,
        Green,

        upgrade_Swipe,
        upgrade_MoneyMultiplier
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Red:  return 50;
            case ItemType.Blue:  return 50;
            case ItemType.Purple:  return 50;
            case ItemType.Pink:  return 50;
            case ItemType.Grey:  return 50;
            case ItemType.Yellow:  return 50;
            case ItemType.Green:  return 50;

            case ItemType.upgrade_Swipe: return 150;
            case ItemType.upgrade_MoneyMultiplier: return 150;
        }

    }

    public static Sprite GetSprite(ItemType itemtype)
    {
        switch(itemtype)
        {
            default:
            case ItemType.Red: return GameAssets.i.red;
            case ItemType.Blue: return GameAssets.i.blue;
            case ItemType.Purple: return GameAssets.i.purple;
            case ItemType.Pink: return GameAssets.i.pink;
            case ItemType.Grey: return GameAssets.i.grey;
            case ItemType.Yellow: return GameAssets.i.yellow;
            case ItemType.Green: return GameAssets.i.green;

            case ItemType.upgrade_Swipe: return GameAssets.i.swipes;
            case ItemType.upgrade_MoneyMultiplier: return GameAssets.i.moneyMultiplier;
        }
    }

    public static Color GetColour(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.Red: return Color.red;
            case ItemType.Blue: return Color.blue;
            case ItemType.Purple: return new Color(127f/255f, 63f/255f, 191f/255f);
            case ItemType.Pink: return new Color(247f/255f, 94f/255f, 170f/255f);
            case ItemType.Grey: return Color.grey;
            case ItemType.Yellow: return Color.yellow;
            case ItemType.Green: return Color.green;
        }
    }

    public static string GetName(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.Red: return "Red";
            case ItemType.Blue: return "Blue";
            case ItemType.Purple: return "Purple";
            case ItemType.Pink: return "Pink";
            case ItemType.Grey: return "Grey";
            case ItemType.Yellow: return "Yellow";
            case ItemType.Green: return "Green";

            case ItemType.upgrade_Swipe: return "Swipes";
            case ItemType.upgrade_MoneyMultiplier: return "2X";

        }
    }

    public static GameObject deathParticles(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Red: return GameAssets.i.red_gm ;
            case ItemType.Blue: return GameAssets.i.blue_gm;
            case ItemType.Purple: return GameAssets.i.purple_gm;
            case ItemType.Pink: return GameAssets.i.pink_gm;
            case ItemType.Grey: return GameAssets.i.grey_gm;
            case ItemType.Yellow: return GameAssets.i.yellow_gm;
            case ItemType.Green: return GameAssets.i.green_gm;
        }
    }

    public static int GetHowMany(ItemType itemType, Player player)
    {
        switch (itemType)
        {
            default:
            case ItemType.upgrade_Swipe: return player.swipes;
            case ItemType.upgrade_MoneyMultiplier: return player.moneyMultiplier;
        }

    }

    //public static textmeshprougui gettextelement(itemtype itemtype, playerupgrademanager playerupgrademanager)
    //{
    //    switch (itemtype)
    //    {
    //        default:
    //        case itemtype.upgrade_swipe:
    //            return playerupgrademanager.
    //    }
    //}

}
