using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour {

    private PlayerInput pInput;
    private PlayerMovement pMovement;
    public Player player;

    public GameObject pointer;
    float speed = 3f;

    public Transform weaponHolder;

    public GameObject weaponObject;

    public Weapon weapon;

    // Use this for initialization
    void Start () {
        StartCoroutine(LookAtPointer());

        pInput = GetComponent<PlayerInput>();
        pMovement = GetComponent<PlayerMovement>();
        player = GetComponent<Player>();

        ChangeWeapon(weaponObject);
        //weaponObject.transform.parent = weaponHolder;
        //weapon = weaponObject.GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {

        pInput.GetInput();

        pMovement.Move(pInput.Hor, pInput.Ver, speed);

        if(pInput.Shoot)
        {
            Shoot();
        }
	}

    void Move()
    {
        
    }

    IEnumerator LookAtPointer()
    {
        while(true)
        {
            Vector3 LookTarget;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

           // Plane p = new Plane();
            

            if(Physics.Raycast(ray,out hit))
            {
                LookTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //LookTarget = new Vector3(hit.point.x, hit.point.y,transform.position.z);
                
                transform.LookAt(LookTarget);


                Vector3 LookWeaponTarget = new Vector3(hit.point.x, 0, hit.point.z);
                weaponObject.transform.LookAt(hit.point);
                weaponObject.transform.Rotate(new Vector3(0, -90, 0));

                pointer.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }

            yield return null;
            //yield return new WaitForSeconds(0.05f);
        }
    }

    public void Shoot()
    {
        weapon.Shoot();
    }

    public void ChangeWeapon(GameObject WOP)
    {
        Destroy(weaponObject);

        GameObject WO = Instantiate(WOP);

        WO.transform.parent = weaponHolder;

        WO.transform.localPosition = Vector3.zero;

        weaponObject = WO;

        weapon = weaponObject.GetComponent<Weapon>();
    }
}
