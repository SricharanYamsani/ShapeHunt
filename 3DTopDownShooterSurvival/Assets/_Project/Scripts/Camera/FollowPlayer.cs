using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Vector3 offset;

    public Transform player;
    void Start () {
        //player = GameManager.Instance.PlayerOne.transform;

        offset = transform.position - player.position;

    }
	
	// Update is called once per frame
	void Update () {

        Move();
    }

    void Move()
    {
        if (player != null)
        {
            Vector3 vel = Vector3.zero;

            transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref vel, 0.05f);

            //transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
    }
}
