using UnityEngine;

/// <summary>
/// Base class for all weapons in game
/// </summary>
public class Weapon : MonoBehaviour {

    public Sprite Icon;

    public int damage;
    public int cost;

    public float SpawnRate = 0.75f;

    public float TimeForNextSpawn = 0f;
    public float ammo;

    /// <summary>
    /// Time taken for the bullet animation to complete
    /// </summary>
    //public float animationRunTime;
    /// <summary>
    /// Position and rotation from where the bullet should be fired 
    /// </summary>
    public Transform muzzle;
    
    /// <summary>
    /// The bullet used by this weapon class
    /// </summary>
    public GameObject bulletPrefab;


    public virtual void Shoot()
    {
        //Debug.Log("Bullet instantiated");
        if (Time.time > TimeForNextSpawn)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, bulletPrefab.transform.rotation);
            TimeForNextSpawn = Time.time + SpawnRate;
            ammo--;


        }
        if (ammo < 0)
        {
            GameManager.Instance.shop.SetWeapon(0);
        }

    }
}
