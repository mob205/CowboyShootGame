using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    private void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = "Level " + LevelManager.instance.GetLevel();
    }
}
