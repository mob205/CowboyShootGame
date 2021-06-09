using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopCanvas : MonoBehaviour
{
    public static ShopCanvas instance;

    GameObject child;
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            child = transform.GetChild(0).gameObject;
        }
    }
    private void Update()
    {
        child.SetActive(SceneManager.GetActiveScene().name == "Shop");
    }
}
