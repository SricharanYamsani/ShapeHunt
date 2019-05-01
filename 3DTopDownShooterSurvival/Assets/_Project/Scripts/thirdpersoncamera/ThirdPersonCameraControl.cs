using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    float rotationSpeed = 50;
    public Transform Target, Player;
    float mouseX, mouseY;

   
    float zoomSpeed = 2f;
    
    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
    

  
}