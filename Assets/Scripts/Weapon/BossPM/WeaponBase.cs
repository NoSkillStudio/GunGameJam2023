using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected float timeBetweenShots;
    protected float nextShotTime;

    [SerializeField] protected int damage;

    [SerializeField] protected int bulletsCount;

    protected virtual void Start()
    {
        bulletPrefab.GetComponent<Bullet>().Damage = damage;
    }

    //protected void BulletActivate(Transform bulletStartPosition, Transform weapon)
    //{
    //    var bullet = bulletsPool.GetBullet(bulletPrefab);
    //    bullet.transform.position = bulletStartPosition.position;
    //    bullet.transform.rotation = weapon.rotation;
    //    bullet.SetActive(true);
    //}

    protected abstract void Shoot();
}