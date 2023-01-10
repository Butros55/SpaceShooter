using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    BuildingManager buildingManager;
    public bool IsPlaced = false;
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        buildingManager.canPlace = false;
        buildingManager.gridOn = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("EditorScreen") && IsPlaced == false) {
            buildingManager.gridOn = true;
            buildingManager.canPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("EditorScreen") && IsPlaced == false) {
            buildingManager.gridOn = false;
            buildingManager.canPlace = false;
        }
    }
}
