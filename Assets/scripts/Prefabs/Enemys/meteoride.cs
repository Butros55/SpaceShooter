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
    private Collider2D Collider;
    private float CurrentExplosionTimer = 0;
    private float RevertedExplosionTimer;
    public float ExplosionTime;
    private bool isDestroyed = false;
    public float ExplosionScale;
    public float ExplosionDivision;
    public Color ExplosionColor;
    private Color ExplosionColorScale;
    float Red;
    float Green;
    float Blue;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        Collider = GetComponent<Collider2D>();
        Red = ExplosionColor.r * 255 / 10;
        Green = ExplosionColor.g * 255 / 10;
        Blue = ExplosionColor.b * 255 / 10;
    }

    // Update is called once per frame
    void Update() {
        if (meteoridelayer0 != null && isDestroyed) {
            CurrentExplosionTimer += Time.deltaTime;
            if (CurrentExplosionTimer <= ExplosionTime * ExplosionDivision) {
            RevertedExplosionTimer = CurrentExplosionTimer;
            ExplosionColorScale = new Color(Red * (CurrentExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision,
            Green * (CurrentExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision,
            Blue * (CurrentExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision);
                meteoridelayer0.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer1.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer2.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer3.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
            }
            else {
                RevertedExplosionTimer -= Time.deltaTime * (ExplosionDivision / (1f - ExplosionDivision));
            ExplosionColorScale = new Color(Red * (RevertedExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision,
            Green * (RevertedExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision,
            Blue * (RevertedExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision);

                meteoridelayer0.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer1.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer2.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                meteoridelayer3.GetComponent<MeshRenderer>().material.color = ExplosionColorScale;
                if (Red * (RevertedExplosionTimer / ExplosionTime) *  ExplosionScale / ExplosionDivision <= Red &&
                    Green * (RevertedExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision <= Green &&
                    Blue * (RevertedExplosionTimer / ExplosionTime) * ExplosionScale / ExplosionDivision <= Blue) {
                    Destroy(meteoridelayer0);
                }
            }
            Debug.Log(ExplosionColorScale);
        }
        // if (!isDestroyed) {
        transform.Translate(Vector2.down * (speed / 10) * Time.deltaTime, Space.World);
        // }
        transform.Rotate(new Vector2(180,180) * Time.deltaTime);
        DestroyMeteroide();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "WeaponParticel") {
            audioSource.Play();
            Collider.enabled = !Collider.enabled;
            isDestroyed = true;
            Destroy(other.gameObject);
        }
    }


    private void DestroyMeteroide() {
    Vector2 position = transform.position;
    if (position.y <= -18) {
        Destroy(gameObject);
    }
    }
}
