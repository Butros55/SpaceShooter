using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 ray = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("Weapon") ||
                    hit.collider.gameObject.CompareTag("BaseObject")) {
                     Select(hit.collider.gameObject);
                }
            }
        }
        if(Input.GetKey(KeyCode.Escape)) {
            Deselect();
        }
    }

    void Select(GameObject obj) {
        if(obj == selectedObject) return;
        if(selectedObject != null) Deselect();
        Outline outline = obj.GetComponent<Outline>();
        if(outline == null) obj.AddComponent<Outline>();
        else outline.enabled = true;
        selectedObject = obj;
    }

    private void Deselect() {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }
}
