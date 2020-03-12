using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Camera mainCamera;
    PlayerController player;

    const float Left = 180f;
    const float Right = 0f;

    float startingY, startingZ;

    void Start()
    {
        player = PlayerController.instance;
        mainCamera = Camera.main;
        startingY = transform.eulerAngles.y;
        startingZ = transform.eulerAngles.z;
    }

    void Update()
    {
        RotateGun();
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
