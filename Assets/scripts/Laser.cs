using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        DestroyLaser();
    }

    private void DestroyLaser() {
        Vector3 position = transform.position;
        if (position.y >= 28) {
            Destroy(gameObject);
        }
    }
}