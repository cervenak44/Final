using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float nextFire;

    public float speed;
    public float fireRate;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public AudioSource AudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            AudioSource.Play();
        }

    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireRate"))
        {
            fireRate = 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("FireRatePositive"))
        {
            fireRate = .1f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("SpeedUP"))
        {
            speed = 20;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("SpeedDOWN"))
        {
            speed = 5;
            other.gameObject.SetActive(false);
        }
    }
}