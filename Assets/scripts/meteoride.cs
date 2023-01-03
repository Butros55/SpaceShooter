using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoride : MonoBehaviour
{
    public float speed;
    public GameObject meteoridelayer;
    AudioSource audioSource;
    private Collider Collider;

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(180,180,0) * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        DestroyMeteroide();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Laser") {
            audioSource.Play();
            Collider.enabled = !Collider.enabled;
            GameManager.instance.Score += 1;
            Destroy(meteoridelayer);
            Destroy(other.gameObject);
        }
    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
    }

    private void DestroyMeteroide() {
    Vector3 position = transform.position;
    if (position.y <= -18) {
        Destroy(gameObject);
    }
    }
}
