using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float minSpeed = 50f;
    public float maxSpeed = 100f;
    public float maxSpinSpeed = 10f;
    Rigidbody2D rb;
    public GameObject explosionEffect;
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize,1);

        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomDirection * randomSpeed);
        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    Vector2 contactPoint = collision.GetContact(0).point; 
    GameObject bounceEffect = Instantiate(explosionEffect, contactPoint, Quaternion.identity);

    // Destroy the effect after 1 second
    Destroy(bounceEffect, 1f);
    }
}
