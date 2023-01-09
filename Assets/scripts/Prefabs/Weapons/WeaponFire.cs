using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject ParticelObject;
    public GameObject WeaponObject;
    public bool autoFire;
    public float shootDelay;
    private float counter;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting() { 
        if(autoFire) {
            if (Input.GetButton("Fire1")) {
                counter -= Time.deltaTime;
                if(counter <= 0) {
                    Instantiate(ParticelObject, WeaponObject.transform.position, WeaponObject.transform.rotation);
                    counter = shootDelay;
                }
            }
        }
        else {
            if (Input.GetButtonDown("Fire1")) {
                counter -= Time.deltaTime;
                if(counter <= 0) {
                    Instantiate(ParticelObject, WeaponObject.transform.position, WeaponObject.transform.rotation);
                    counter = shootDelay;
                }
            }
        }
    }
}
