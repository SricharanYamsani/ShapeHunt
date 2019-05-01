using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Vector3 dir;

    public int damage = 10;

    float speed = 15f;
	// Use this for initialization
	void Start () {

        dir = GameManager.Instance.PlayerOne.weaponObject.transform.right;

        Destroy(this.gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( dir * speed * Time.deltaTime, Space.Self);
	}

    private void OnTriggerEnter(Collider other)
    {
        //Enemy enemy = other.GetComponent<Enemy>();

        if(other.CompareTag("Enemy"))
        {
            Enemy enemy = other.transform.parent.GetComponent<Enemy>();

            if (enemy != null)
            {
                //Debug.Log("Hit Enemy");
                enemy.TakeDamage(damage);

                Destroy(this.gameObject);
            }
        }

       

    }
}
