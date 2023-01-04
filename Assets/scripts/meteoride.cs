using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoride : MonoBehaviour
{
    public float speed;
    public GameObject meteoridelayer0;
    public GameObject meteoridelayer1;
    public GameObject meteoridelayer2;
    public GameObject meteoridelayer3;
    AudioSource audioSource;
    private Collider Collider;
    public float ExplosionTimer;
    public float DestroyTimer;
    private bool isDestroyed = false;
    public float ExplosionDuration;
    private Color ExplosionColor;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

            if (meteoridelayer0 != null && isDestroyed) {
            ExplosionTimer -= Time.deltaTime;
            ExplosionColor = new Color(40 / (ExplosionTimer * ExplosionDuration), 10 / (ExplosionTimer * ExplosionDuration), 0 / (ExplosionTimer * ExplosionDuration));
            meteoridelayer0.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            meteoridelayer1.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            meteoridelayer2.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            meteoridelayer3.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            if (ExplosionTimer <= 0) {
                Destroy(meteoridelayer0);
            }
        }
        transform.Rotate(new Vector3(180,180,0) * Time.deltaTime);
        DestroyMeteroide();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Laser") {
            audioSource.Play();
            Collider.enabled = !Collider.enabled;
            isDestroyed = true;
            Destroy(other.gameObject);
        }
    }


    private void DestroyMeteroide() {
    Vector3 position = transform.position;
    if (position.y <= -18 || DestroyTimer <= 0) {
        Destroy(gameObject);
    }
    }
}
