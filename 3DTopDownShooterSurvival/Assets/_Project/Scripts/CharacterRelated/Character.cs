using UnityEngine;

/// <summary>
/// Base class for all classes in game that are damagable
/// </summary>
public abstract class Character : MonoBehaviour {

    protected float health;

	public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
       
    }
    
    public virtual void TakeDamage(int damage)
    {
       Health -= damage;
    }
}
