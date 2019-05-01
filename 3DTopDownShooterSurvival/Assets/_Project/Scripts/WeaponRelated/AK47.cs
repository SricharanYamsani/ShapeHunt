using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon {

	// Use this for initialization
	void Start () {
        SpawnRate = 0.1f;
        ammo = 40;

        damage = 20;

        bulletPrefab.GetComponent<Bullet>().damage = damage;
	}
	
	
}
