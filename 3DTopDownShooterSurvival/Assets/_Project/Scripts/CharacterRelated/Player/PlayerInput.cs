using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    float _h, _v;
    bool shoot = false;

    public bool Shoot { get { return shoot; } }
    public float Hor { get { return _h; } }
    public float Ver { get { return _v; } }

    public void GetInput()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0) )
        {
            shoot = true;
        }
        else
        {
            shoot = false;
        }
    }

}
