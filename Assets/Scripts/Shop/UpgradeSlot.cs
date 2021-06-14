using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSlot : MonoBehaviour
{
    public Upgrade upgrade;
    public Sprite image;
    public string upgName = "OUT OF STOCK";
    public string desc = "NO ITEMS HERE. SORRY!";
    public int level = 1;
    [HideInInspector] public int cost;

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] Image itemImage;
    void Start()
    {
        UpdateCost();
        itemImage.sprite = image;
    }
    
    void UpdateCost()
    {
        if (upgrade)
        {
            cost = upgrade.GetCost(level);
        }
        costText.text = cost.ToString();
    }
    public void BuyUpgrade()
    {
        if (CoinCounter.Coins >= cost && level <= upgrade.maxLevel)
        {
            CoinCounter.RemoveCoins(cost);
            UpgradeManager.instance.AddUpgrade(upgrade, level);
            level++;
            UpdateCost();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
