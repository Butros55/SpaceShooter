using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    public float speed;
    public GameObject LaserObject;
    public GameObject CannonLeft;
    public GameObject CannonRight;
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
        Shooting();
        Movement();
        StartOfLevel();
    }

    void Movement()
    {
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(movement);
        
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -29, 29);
        transform.position = position;

    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(LaserObject, CannonRight.transform.position, LaserObject.transform.rotation);
            Instantiate(LaserObject, CannonLeft.transform.position, LaserObject.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Meteoride")
        {
            audioSource.Play();
            Destroy(other.gameObject);
            Destroy(SpaceShipDestroy);
        }
    }

    private void StartOfLevel() {
        Vector3 movement = Vector3.up * 10 * Time.deltaTime;

        Vector3 position = transform.position;
        if (position.y < -10) {
            transform.Translate(movement);
        }
    }
}
