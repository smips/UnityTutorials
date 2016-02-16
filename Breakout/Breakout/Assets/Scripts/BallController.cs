using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float xStartVelocity;
    public float velocityIncrease;
    public float maxMagnitude;
    public float maxPlayerRebound;
    public PlayerController player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.velocity = new Vector3(rb.velocity.x + Random.Range(-xStartVelocity, xStartVelocity), rb.velocity.y, rb.velocity.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("North Wall") || other.CompareTag("Block"))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
        }
        else if (other.CompareTag("Vertical Wall"))
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
        else if (other.CompareTag("Player"))
        {
            float deltaX = Mathf.Clamp(player.deltaMouseX/25, -maxPlayerRebound, maxPlayerRebound);
            rb.velocity = new Vector3(rb.velocity.x + deltaX, rb.velocity.y, -rb.velocity.z);
            if (rb.velocity.magnitude < maxMagnitude)
            {
                rb.velocity = rb.velocity * velocityIncrease;
            }            
        }
    }


}
