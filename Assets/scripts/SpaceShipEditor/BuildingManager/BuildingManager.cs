using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour, IDataPersistence
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
    public float rotateAmount;
    [SerializeField] private Toggle gridToggle;
    public Material BaseMaterial;
    private int lastIndex;
    private List<int> ObjectPrefab;
    private List<int> ObjectIndexes;
    private List<Vector3> ObjectPosition;
    private List<Quaternion> ObjectRotation;
    private int ObjectIndex;


    public void LoadData(GameData data) {
        this.ObjectPrefab = null;
        this.ObjectIndexes = null;
        this.ObjectPosition = null;
        this.ObjectRotation = null;
        this.ObjectPrefab = data.ObjectPrefab;
        this.ObjectIndexes = data.ObjectIndexes;
        this.ObjectPosition = data.ObjectPosition;
        this.ObjectRotation = data.ObjectRotation;
        foreach (int Index in this.ObjectIndexes) {
            Debug.Log(Index);
            Instantiate(objects[this.ObjectPrefab[Index]], this.ObjectPosition[Index], this.ObjectRotation[Index]);
        }
    }

    public void SaveData(ref GameData data) {
        data.ObjectPrefab = this.ObjectPrefab;
        data.ObjectIndexes = this.ObjectIndexes;
        data.ObjectPosition = this.ObjectPosition;
        data.ObjectRotation = this.ObjectRotation;
    }

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


            if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift)) {
                PlaceObjectMutiple();
            }
            else if(Input.GetMouseButtonDown(0) && canPlace) {
                PlaceObjectSingle();
            }

            if(Input.GetMouseButtonDown(1)) {
                UnselectObject();
            }
            if(Input.GetKeyDown(KeyCode.R)) {
                RotateObject();
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
        BaseMaterial = pendingObject.GetComponent<MeshRenderer>().material;
        lastIndex = index;
    }

    public void PlaceObjectSingle() {
        pendingObject.GetComponent<MeshRenderer>().material = BaseMaterial;
        this.ObjectPrefab.Add(this.lastIndex);
        this.ObjectIndexes.Add(this.ObjectIndex);
        this.ObjectPosition.Add(pendingObject.transform.position);
        this.ObjectRotation.Add(pendingObject.transform.rotation);
        this.ObjectIndex += 1;
        pendingObject = null;
        Debug.Log(this.ObjectPrefab.Count);
        Debug.Log(this.ObjectIndex);
    }

    public void PlaceObjectMutiple() {
        pendingObject.GetComponent<MeshRenderer>().material = BaseMaterial;
        if(canPlace) {
            this.ObjectPrefab.Add(this.lastIndex);
            this.ObjectIndexes.Add(this.ObjectIndex);
            this.ObjectPosition.Add(pendingObject.transform.position);
            this.ObjectRotation.Add(pendingObject.transform.rotation);
            this.ObjectIndex += 1;
            Debug.Log(this.ObjectIndex);
            Debug.Log(this.ObjectPrefab.Count);
            pendingObject = null;
            pendingObject = Instantiate(objects[lastIndex], pos, transform.rotation);
        }
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

    void RotateObject() {
        pendingObject.transform.Rotate(Vector3.back, rotateAmount);
    }
}
