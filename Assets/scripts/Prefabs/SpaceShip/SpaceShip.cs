using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    public float speed;
    public GameObject SpaceShipDestroy;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StartOfLevel();
    }

    void Movement()
    {
        Vector2 movement = Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(movement);
        
        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, -8.5f, 8.5f);
        transform.position = position;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Meteoride")
        {
            audioSource.Play();
            Destroy(other.gameObject);
            Destroy(SpaceShipDestroy);
        }
    }

    private void StartOfLevel() {
        Vector2 movement = Vector2.up * 5 * Time.deltaTime;

        Vector2 position = transform.position;
        if (position.y < -4.2f) {
            transform.Translate(movement);
        }
    }
}
