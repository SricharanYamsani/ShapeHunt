using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SphereEnemy : Enemy
{

    Transform target;

    NavMeshAgent agent;

    public int maxHealth ;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(GetTargetPosition());

        Health = maxHealth;

        type = EnemyType.SPHERE;

        value = 100;
    }

    IEnumerator GetTargetPosition()
    {
        while (true)
        {
            if (GameManager.Instance.PlayerOne != null)
            {
                target = GameManager.Instance.PlayerOne.transform;//.position;

                if (target != null)
                {
                    agent.SetDestination(new Vector3(target.position.x, transform.position.y, target.position.z));

                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                break;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }

    }

    public override void Die()
    {
        //base.Die();
        Debug.Log("Enemy Dead");
        //Destroy(this.gameObject);
        EnemySpawner.Instance.BackToPool(EnemyType.SPHERE, this.gameObject);

        GameManager.Instance.UpdateScore(value);

        //Heal player Randomly

        if (Random.Range(0f, 1f) > 0.5f)
            GameManager.Instance.PlayerOne.player.Heal(5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("COllision");
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            //die animation;

            GameManager.Instance.PlayerOne.player.TakeDamage(10);

            //Destroy(this.gameObject);
            EnemySpawner.Instance.BackToPool(EnemyType.SPHERE, this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            //die animation;

            GameManager.Instance.PlayerOne.player.TakeDamage(10);

            //Destroy(this.gameObject);
            EnemySpawner.Instance.BackToPool(EnemyType.SPHERE, this.gameObject);

        }
    }
}
