using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.TestTools;

public class UI_Upgrades : MonoBehaviour
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private Transform shopItemTemplate;
    private Player player;
    private PlayerUpgradeManager playerUpgradeManager;
    public float shopItemHeight = 130f;
    Transform shopItemTransform;

    //GameObjects referencing the buttons


    private void Awake()
    {
        //container = transform.Find("container");
        //shopItemTemplate = transform.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerUpgradeManager = player.GetComponent<PlayerUpgradeManager>();
        CreateUpgrades();
    }

    public void CreateUpgrades()
    {

        DestroyButtons();


        CreateItemButton(Item.ItemType.upgrade_MoneyMultiplier, Item.GetSprite(Item.ItemType.upgrade_MoneyMultiplier),
            Item.GetCost(Item.ItemType.upgrade_MoneyMultiplier), Item.GetName(Item.ItemType.upgrade_MoneyMultiplier),
            ("You Have: " + Item.GetHowMany(Item.ItemType.upgrade_MoneyMultiplier, player).ToString()), 0);

        CreateItemButton(Item.ItemType.upgrade_Swipe, Item.GetSprite(Item.ItemType.upgrade_Swipe), 
            Item.GetCost(Item.ItemType.upgrade_Swipe), Item.GetName(Item.ItemType.upgrade_Swipe), 
            ("You Have: " + Item.GetHowMany(Item.ItemType.upgrade_Swipe, player).ToString()), 1);


        

        
    }

    void DestroyButtons()
    {
        GameObject[] upgradeTemplates = GameObject.FindGameObjectsWithTag("UpgradeTemplate");

        foreach(GameObject template in upgradeTemplates)
        {
            GameObject.Destroy(template);
        }


    }

    private Transform CreateItemButton(Item.ItemType itemType, Sprite itemSprite, int itemCost, string itemName, string howMany ,int positionIndex)
    {
        shopItemTransform = Instantiate(shopItemTemplate, content);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();


        //shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);


        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("titleText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("HowManyText").GetComponent<TextMeshProUGUI>().SetText(howMany.ToString());

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };

        shopItemTransform.gameObject.SetActive(true);
        return null;
    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        playerUpgradeManager.BoughtUpgrade(itemType);

    }


}
