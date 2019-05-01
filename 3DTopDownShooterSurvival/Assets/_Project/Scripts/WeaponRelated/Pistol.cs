using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    private void Start()
    {
        damage = 10;
        bulletPrefab.GetComponent<Bullet>().damage = damage;

    }

    public override void Shoot()
    {
        ammo = 2;
        base.Shoot();
    }

}
