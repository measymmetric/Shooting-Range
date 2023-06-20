using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Gun;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;
    public bool equipped = true;

    void Start()
    {
       Gun.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (equipped == true)
            {
                UnequipObject();
            }
            else
            {
                EquipObject();
            }
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            var target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(10f);
                Debug.Log("working");
            }
        }
    }

    void UnequipObject()
    {
        equipped = false;
        PlayerTransform.DetachChildren();
        Gun.transform.eulerAngles = new Vector3(Gun.transform.eulerAngles.x, Gun.transform.eulerAngles.y, Gun.transform.eulerAngles.z - 45);
        Gun.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        equipped = true;
        Gun.GetComponent<Rigidbody>().isKinematic = true;
        Gun.transform.position = PlayerTransform.transform.position;
        Gun.transform.rotation = PlayerTransform.transform.rotation;
        Gun.transform.SetParent(PlayerTransform);
    }
}
