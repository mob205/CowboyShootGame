using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] Image dispImage;
    [SerializeField] TextMeshProUGUI dispName;
    [SerializeField] TextMeshProUGUI dispDesc;
    [SerializeField] TextMeshProUGUI dispPrice;
    [SerializeField] TextMeshProUGUI dispLevel;

    // Update is called once per frame
    void Update()
    {
        CheckSelection();
    }
    void CheckSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            var hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);
            if (hit)
            {
                var slot = hit.collider.GetComponent<UpgradeSlot>();
                dispImage.sprite = slot.image;
                dispName.text = slot.upgName;
                dispDesc.text = slot.desc;
                dispPrice.text = slot.cost.ToString();
                dispLevel.text = "Level " + slot.level.ToString();
            }
        }
    }
}
