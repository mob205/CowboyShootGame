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
    [TextArea] public string desc = "NO ITEMS HERE. SORRY!";
    public int level = 1;
    [HideInInspector] public int cost;

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] Image itemImage;
    [SerializeField] AudioSource purchaseSound;
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
            costText.text = cost.ToString();
        }
        else
        {
            return;
        }
        if (level > upgrade.maxLevel)
        {
            costText.text = "MAX";
        }
    }
    public void BuyUpgrade()
    {
        if (CoinCounter.Coins >= cost && level <= upgrade.maxLevel)
        {
            CoinCounter.RemoveCoins(cost);
            UpgradeManager.instance.AddUpgrade(upgrade, level);
            level++;
            UpdateCost();
            purchaseSound.PlayOneShot(purchaseSound.clip);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
