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
    [HideInInspector] public int cost;
    [HideInInspector] public int level;

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] Image itemImage;
    void Start()
    {
        if (upgrade)
        {
            cost = upgrade.cost;
            level = upgrade.level;
        }
        costText.text = cost.ToString();
        itemImage.sprite = image;
    }
    
    public void BuyUpgrade()
    {
        if(CoinCounter.coins >= cost)
        {
            CoinCounter.coins -= cost;
            UpgradeManager.instance.AddUpgrade(upgrade);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
