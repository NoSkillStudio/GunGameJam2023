using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : WeaponBase
{
    [SerializeField] private UnityEvent OnShot;

    private float bulletsInMagazine = 25;

    private bool canShoot = true;

    [SerializeField] private float rechargeTime = 10f;

    [SerializeField] private KeyCode fire;
    private void Update()
    {
        if (canShoot)
        {
            if (Time.time > nextShotTime)
            {
                if (Input.GetKey(fire))
                {
                    Shoot();
                    nextShotTime = Time.time + timeBetweenShots;
                }
            }

        }

    }


    protected override void Shoot()
    {
        bulletsInMagazine--;
        if (bulletsInMagazine <= 1)
        {
            RechargeMagazine();
        }
        //BulletActivate(firePoint, transform);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void RechargeMagazine()
    {
        canShoot = false;
        bulletsInMagazine = 25;
        Invoke("ActiveShoot", rechargeTime);
    }

    private void ActiveShoot() => canShoot = true;
}