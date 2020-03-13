using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawn;

    [Header("Stats")]
    [SerializeField] float damage;
    [SerializeField] float bulletSpeed;
    [SerializeField] float reloadTime;
    [SerializeField] float bulletLifetime;

    Camera mainCamera;
    PlayerController player;

    const float Left = 180f;
    const float Right = 0f;

    float startingY, startingZ;
    bool canShoot = true;

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
        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Fire();
        }
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
    void Fire()
    {
        if (canShoot)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.shooter = player.gameObject;
            bullet.damage = damage;
            bullet.speed = bulletSpeed;
            Destroy(bullet.gameObject, bulletLifetime);
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
