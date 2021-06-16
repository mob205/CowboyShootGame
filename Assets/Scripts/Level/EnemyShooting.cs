using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    GunController gun;
    GunPivot pivot; 
    void Start()
    {
        gun = GetComponentInChildren<GunController>();
        pivot = GetComponentInChildren<GunPivot>();
        gun.damage *= LevelManager.instance.damageMod;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.SetTarget(PlayerController.instance.transform.position);
        gun.Fire();
    }
}
