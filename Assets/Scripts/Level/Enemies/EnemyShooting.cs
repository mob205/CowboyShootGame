using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] float reloadDeviation;
    GunController gun;
    GunPivot pivot;

    float baseReloadTime;
    void Start()
    {
        gun = GetComponentInChildren<GunController>();
        pivot = GetComponentInChildren<GunPivot>();
        gun.damage *= LevelManager.instance.damageMod;
        baseReloadTime = gun.reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.SetTarget(PlayerController.instance.transform.position);
        if (gun.canShoot)
        {
            gun.reloadTime = baseReloadTime + Random.Range(-reloadDeviation, reloadDeviation);
        }
        gun.Fire();
    }
}
