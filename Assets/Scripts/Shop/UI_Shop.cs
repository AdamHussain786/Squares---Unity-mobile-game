using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.TestTools;

public class UI_Shop : MonoBehaviour
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private Transform shopItemTemplate;
    private Player player;
    PlayerUpgradeManager playerUpgradeManager;
    GameMaster gm;
    public float shopItemHeight = 130f;

    private void Awake()
    {
        //container = transform.Find("container");
        //shopItemTemplate = transform.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {   
        playerUpgradeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeManager>();

        CreateItemButton(Item.ItemType.Red, Item.GetSprite(Item.ItemType.Red), Item.GetCost(Item.ItemType.Red), 0);
        CreateItemButton(Item.ItemType.Blue, Item.GetSprite(Item.ItemType.Blue), Item.GetCost(Item.ItemType.Blue), 1);
        CreateItemButton(Item.ItemType.Purple, Item.GetSprite(Item.ItemType.Purple), Item.GetCost(Item.ItemType.Purple), 2);
        CreateItemButton(Item.ItemType.Pink, Item.GetSprite(Item.ItemType.Pink), Item.GetCost(Item.ItemType.Pink), 3);
        CreateItemButton(Item.ItemType.Grey, Item.GetSprite(Item.ItemType.Grey), Item.GetCost(Item.ItemType.Grey), 4);
        CreateItemButton(Item.ItemType.Yellow, Item.GetSprite(Item.ItemType.Yellow), Item.GetCost(Item.ItemType.Yellow), 5);
        CreateItemButton(Item.ItemType.Green, Item.GetSprite(Item.ItemType.Green), Item.GetCost(Item.ItemType.Green), 6);
        
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, content);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        
        //shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);


        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };

        shopItemTransform.gameObject.SetActive(true);
    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        if(playerUpgradeManager == null)
        {
            playerUpgradeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUpgradeManager>();
            playerUpgradeManager.BoughtItem(itemType);
        }
        else
        {
            playerUpgradeManager.BoughtItem(itemType);
        }
        
        
    }
}
