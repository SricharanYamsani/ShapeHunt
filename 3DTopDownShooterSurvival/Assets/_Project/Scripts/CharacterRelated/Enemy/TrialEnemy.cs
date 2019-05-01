using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TrialEnemy : Enemy {

    public Transform target;

    NavMeshAgent agent;

    int maxHealth = 30;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(GetTargetPosition());

        Health = maxHealth;

        Debug.Log(this.gameObject.name + " : " + transform.position.y);
    }

    IEnumerator GetTargetPosition()
    {
        while(true)
        {
            if (GameManager.Instance.PlayerOne != null)
            {
                target = GameManager.Instance.PlayerOne.transform;//.position;

                if (target != null)
                {
                    Vector3 dest = new Vector3(target.position.x, /*transform.position.y*/1.0f + transform.position.y, target.position.z);

                    agent.SetDestination(dest);

                    Debug.Log(dest);

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
        if(Health <= 0)
        {
            Die();
        }

    }

    public override void Die()
    {
        //base.Die();
        Debug.Log("Enemy Dead");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("COllision");
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            //die animation;

            GameManager.Instance.PlayerOne.player.TakeDamage(10);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            //die animation;

            GameManager.Instance.PlayerOne.player.TakeDamage(10);

            Destroy(this.gameObject);
        }
    }
}
