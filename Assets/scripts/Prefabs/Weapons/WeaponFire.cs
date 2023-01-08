using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject ParticelObject;
    public GameObject WeaponObject;
    public bool autoFire;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting() { 
        if(autoFire) {
            if (Input.GetButton("Fire1")) {
                Instantiate(ParticelObject, WeaponObject.transform.position, ParticelObject.transform.rotation);
            }
        }
        else {
            if (Input.GetButtonDown("Fire1")) {
                Instantiate(ParticelObject, WeaponObject.transform.position, ParticelObject.transform.rotation);
            }
        }
    }
}
