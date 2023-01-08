using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeckPlacementWeapon : MonoBehaviour
{
    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingManager.canPlace = false;
        buildingManager.gridOn = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BaseObject")) {
            buildingManager.canPlace = true;
        }
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = true;
            buildingManager.canPlace = true;
        }
        if(other.gameObject.CompareTag("Weapon")) {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("BaseObject")) {
            buildingManager.canPlace = false;
        }
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = false;
            buildingManager.canPlace = false;
        }
    }
}
