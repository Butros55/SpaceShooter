using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacementWeapon : MonoBehaviour
{
    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingManager.canPlace = false;
        buildingManager.gridOn = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = true;
            buildingManager.canPlace = false;
        }
        if(other.gameObject.CompareTag("Weapon")) {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("EditorScreen")) {
            buildingManager.gridOn = false;
            buildingManager.canPlace = false;
        }
        if(other.gameObject.CompareTag("BaseObject")) {
            buildingManager.canPlace = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("BaseObject")) {
            buildingManager.canPlace = true;
        }
    }
}