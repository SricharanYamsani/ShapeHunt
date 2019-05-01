using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    CUBE,
    SPHERE,
    CYLINDER,
    DISAPPEAR,
    ENLARGE
}

public class Enemy : Character {

    public int value;//Value that will be added to score if Enemy dies

    //[SerializeField]
    //protected int maxHealth;
	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public EnemyType type;

    public override void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage");
    }

    public virtual void OnPlayerTouched()
    {
        Debug.Log("Touched enemy");
    }

    public virtual void Init()
    {

    }

    public virtual void Die()
    {
        Debug.Log("Enemy died.!");
    }
}
