using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUIUpdater : MonoBehaviour
{
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = CoinCounter.coins.ToString();
    }
}
