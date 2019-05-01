using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4 : Weapon {

	// Use this for initialization
	void Start () {
        SpawnRate = 0.15f;

        ammo = 60;

        damage = 20;

        bulletPrefab.GetComponent<Bullet>().damage = damage;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
