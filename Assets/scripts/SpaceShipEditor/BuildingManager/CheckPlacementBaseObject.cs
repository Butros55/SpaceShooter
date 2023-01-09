using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacementBaseObject : MonoBehaviour
{
    BuildingManager buildingManager;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingManager.canPlace = true;
        buildingManager.gridOn = true;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("BaseObject")) {
    //         buildingManager.canPlace = false;
    //     }
    //     if(other.gameObject.CompareTag("EditorScreen")) {
    //         buildingManager.gridOn = true;
    //         buildingManager.canPlace = true;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("BaseObject")) {
    //         buildingManager.canPlace = true;
    //     }
    //     if(other.gameObject.CompareTag("EditorScreen")) {
    //         buildingManager.gridOn = false;
    //         buildingManager.canPlace = false;
    //     }
    // }
}
