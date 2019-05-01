using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public void Move(float h,float v,float speed)
    {
        Vector3 dir = new Vector3(h,0,v);

        //transform.Translate(dir * Time.deltaTime * speed);

        transform.position += (dir * Time.deltaTime * speed);
    }
}
