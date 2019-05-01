using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main player class
/// </summary>
public class Player : Character {

    /// <summary>
    /// Sensitivity of touch
    /// </summary>
    //float sensitivity = 0.5f;

    int maxHealth = 100;
       

    // Use this for initialization
    void Start() {
        Health = maxHealth;


        GameManager.Instance._UIManager.UpdateHealthText(Health);
    }

    // Update is called once per frame
    void Update() {

    }

    public override void TakeDamage(int damage)
    {
        //base.TakeDamage(damage);
        Health -= damage;

        GameManager.Instance._UIManager.UpdateHealthText(Health);

        if (Health <= 0)
            Die();


    }

    public void Heal(int healAmount)
    {
        Health += healAmount;


        if (Health > maxHealth)
            Health = maxHealth;


        GameManager.Instance._UIManager.UpdateHealthText(Health);
    }

    void Die()
    {
        Debug.Log("Player Dead");
        Destroy(this.gameObject);

        GameManager.Instance.OnPlayerDeath();
    }

}
