using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemyChild : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("COllision");
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Touched Player");
            //die animation;

            GameManager.Instance.PlayerOne.player.TakeDamage(10);

            //Destroy(this.gameObject);

            EnemySpawner.Instance.BackToPool(EnemyType.CUBE, transform.parent.gameObject);
            //Die();
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

            EnemySpawner.Instance.BackToPool(EnemyType.CUBE, transform.parent.gameObject);
            //Die();
        }
    }
}
