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
    public float CurrentExplosionTimer = 0;
    public float RevertedExplosionTimer;
    public float ExplosionTime;
    private bool isDestroyed = false;
    public float ExplosionScale;
    public float ExplosionDivision;
    private Color ExplosionColor;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
        if (meteoridelayer0 != null && isDestroyed) {
            CurrentExplosionTimer += Time.deltaTime;
            if (CurrentExplosionTimer <= ExplosionTime * ExplosionDivision) {
                RevertedExplosionTimer = CurrentExplosionTimer;
                ExplosionColor = new Color(40 * (CurrentExplosionTimer  / ExplosionTime * ExplosionScale), 10 * (CurrentExplosionTimer  / ExplosionTime * ExplosionScale), 1 * (CurrentExplosionTimer  / ExplosionTime * ExplosionScale));
                meteoridelayer0.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer1.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer2.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer3.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            }
            else {
                RevertedExplosionTimer -= Time.deltaTime * (ExplosionDivision / (1f - ExplosionDivision));
                ExplosionColor = new Color(40 * (RevertedExplosionTimer  / ExplosionTime * ExplosionScale), 10 * (RevertedExplosionTimer  / ExplosionTime * ExplosionScale), 1 * (RevertedExplosionTimer  / ExplosionTime * ExplosionScale));
                meteoridelayer0.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer1.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer2.GetComponent<MeshRenderer>().material.color = ExplosionColor;
                meteoridelayer3.GetComponent<MeshRenderer>().material.color = ExplosionColor;
            }
            if (CurrentExplosionTimer >= ExplosionTime) {
                Destroy(meteoridelayer0);
            }
            Debug.Log(ExplosionColor);
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
    if (position.y <= -18) {
        Destroy(gameObject);
    }
    }
}
