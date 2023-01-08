using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeckPlacementBaseObject : MonoBehaviour
{
    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingManager.canPlace = false;
        buildingManager.gridOn = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BaseObject") || other.gameObject.CompareTag("Weapon")) {
            buildingManager.canPlace = false;
        }
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = true;
            buildingManager.canPlace = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("BaseObject") || other.gameObject.CompareTag("Weapon")) {
            buildingManager.canPlace = true;
        }
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = false;
            buildingManager.canPlace = false;
        }
    }
}
