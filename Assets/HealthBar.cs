using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Slider slider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetHealthBar(float percent)
    {
        slider.value = percent;
    }
}
