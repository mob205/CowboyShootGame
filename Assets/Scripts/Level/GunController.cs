using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject parent;
    [SerializeField] public AudioSource shootSound;

    [Header("Stats")]
    public float damage;
    public float bulletSpeed;
    public float reloadTime;
    [SerializeField] float bulletLifetime;

    GunPivot pivot;

    [HideInInspector] public float startingY, startingZ;
    public bool canShoot = true;

    void Awake()
    {
        startingY = transform.eulerAngles.y;
        startingZ = transform.eulerAngles.z;
        pivot = GetComponentInParent<GunPivot>();
    }

    void LateUpdate()
    {
        RotateGun();
    }
    void RotateGun()
    {
        if(parent.GetComponent<Enemy>())
        {
            Debug.Log($"Tank transform: {parent.transform.position.x}");
            Debug.Log($"Player transform: {PlayerController.instance.transform.position.x}");
            Debug.Log($"Target transform: {pivot.target.x}");
            Debug.Log(pivot.target == PlayerController.instance.transform.position);
        }
        if (pivot.target.x < parent.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(180, startingY, -startingZ));
        }
        else
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, startingY, startingZ));
        }
    }
    public void Fire()
    {
        if (canShoot)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.shooter = parent.gameObject;
            bullet.damage = damage;
            bullet.speed = bulletSpeed;
            Destroy(bullet.gameObject, bulletLifetime);
            StartCoroutine(Reload());
            shootSound.PlayOneShot(shootSound.clip);
        }
    }
    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
