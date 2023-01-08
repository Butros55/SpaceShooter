using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    [SerializeField] private Material[] materials;
    private GameObject pendingObject;

    private Vector2 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    public float gridSize;
    public bool gridOn;
    public bool canPlace;
    public bool isPlaced = false;
    [SerializeField] private Toggle gridToggle;

    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null) {
            if(gridOn) {
                pendingObject.transform.position = new Vector2(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y)
                    );
            }

            else {
                pendingObject.transform.position = pos;
            }

            UpdateMaterials();

            if(Input.GetMouseButtonDown(0) && canPlace) {
                PlaceObject();
            }

            if(Input.GetMouseButtonDown(1)) {
                UnselectObject();
            }
        }
    }

    private void FixedUpdate() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask)) {
            pos = hit.point;
        }
    }

    public void SelectObject(int index) {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
    }

    public void PlaceObject() {
        isPlaced = true;
        pendingObject.GetComponent<MeshRenderer>().material = materials[2];
        pendingObject = null;
    }

    public void UnselectObject() {
        Destroy(pendingObject);
    }

    public void ToggleGrid() {
        if(gridToggle.isOn) {
            gridOn = true;
        }
        else {
            gridOn = false;
        }
    }

    float RoundToNearestGrid(float pos) {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2)) {
            pos += gridSize;
        }
        return pos;
    }

    void UpdateMaterials() {
        if(canPlace) {
            pendingObject.GetComponent<MeshRenderer>().material = materials[0];
        }
        if(!canPlace) {
            pendingObject.GetComponent<MeshRenderer>().material = materials[1];
        }
    }
}
