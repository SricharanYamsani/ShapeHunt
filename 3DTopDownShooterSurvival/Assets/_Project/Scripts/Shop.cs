using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject[] weapons;
    public int[] weaponCosts;

    public void SetWeapon(int index)
    {

        if (weaponCosts[index] < GameManager.Instance.PlayerOne.player.Health)
        {
            GameManager.Instance.PlayerOne.ChangeWeapon(weapons[index]);

            Debug.Log("Weapon changed to " + weapons[index].name);

            GameManager.Instance.PlayerOne.player.TakeDamage(weaponCosts[index]);
        }
        else
        {
            Debug.Log("Player health is less");
            Debug.Log("Health : " + GameManager.Instance.PlayerOne.player.Health + " Cost : " + weaponCosts[index]);
        }
    }


    public void SetShop()
    {
        gameObject.SetActive(false);
    }
}
