/// <summary>
/// Interface responsible for making a gameobject take damage
/// </summary>
public interface IDamagable
{
    /// <summary>
    /// Health of the object
    /// </summary>
    float Health { get; set; }

    /// <summary>
    /// Function to manipulate health
    /// </summary>
    /// <param name="damage"></param>
    void TakeDamage(int damage);
}
