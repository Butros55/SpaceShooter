using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject selectedObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 raycastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastPos, Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("Weapon") &&
                    hit.collider.GetComponent<CheckPlacement>().IsPlaced == true ||
                    hit.collider.gameObject.CompareTag("BaseObject") &&
                    hit.collider.GetComponent<CheckPlacement>().IsPlaced == true) {

                    Debug.Log("Obj" + hit.collider.gameObject.name);
                    Select(hit.collider.gameObject);
                }
            }
        }
        if(Input.GetKey(KeyCode.Escape)) {
            if(selectedObject != null) {
                Deselect();
            }
        }
    }

    void Select(GameObject obj) {
        if(obj == selectedObject) return;
        if(selectedObject != null) Deselect();
        Outline outline = obj.GetComponent<Outline>();
        if(outline == null) {
            obj.AddComponent<Outline>();
        }
        else {
            outline.enabled = true;
        }
        selectedObject = obj;
    }

    private void Deselect() {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
}
