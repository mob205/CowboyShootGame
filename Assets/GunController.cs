using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform pivot;
    Camera mainCamera;
    PlayerController player;

    const float Left = 180f;
    const float Right = 0f;

    float startingY, startingZ;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        mainCamera = Camera.main;
        startingY = transform.eulerAngles.y;
        startingZ = transform.eulerAngles.z;
    }

    void Update()
    {
        RotatePivot();
        RotateGun();
    }
    void RotatePivot()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var pivotPos = pivot.position;

        mousePos.x -= pivotPos.x;
        mousePos.y -= pivotPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        pivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void RotateGun()
    {
        if (Input.mousePosition.x < mainCamera.WorldToScreenPoint(player.transform.position).x)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(180, startingY, startingZ));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, startingY, startingZ));
        }
    }
}
