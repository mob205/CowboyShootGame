using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUIUpdater : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = CoinCounter.coins.ToString();
    }
}
