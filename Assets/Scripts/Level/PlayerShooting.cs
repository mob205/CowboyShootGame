using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [HideInInspector] public GunController[] guns;
    [HideInInspector] public GunPivot pivot;

    Camera cam;
    void Start()
    {
        SetGuns();
        pivot = GetComponentInChildren<GunPivot>();
        cam = Camera.main;
    }
    private void Update()
    {
        pivot.SetTarget(cam.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            FireGuns();
        }
    }
    public void SetGuns()
    {
        guns = GetComponentsInChildren<GunController>();
    }
    private void FireGuns()
    {
        foreach(var gun in guns)
        {
            gun.Fire();
        }
    }
}
