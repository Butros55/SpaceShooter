using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject LaserObject;
    public GameObject Weapon;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(LaserObject, Weapon.transform.position, LaserObject.transform.rotation);
        }
    }
}
