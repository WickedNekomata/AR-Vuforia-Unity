using UnityEngine;

public class ballPong : MonoBehaviour
{
    Rigidbody rb;

    public float constantSpeed = 1.0f;
    public float increaseOverBound = 0.01f;

    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        rb.AddForce(Random.Range(0.0f, 1.0f), 0.5f, Random.Range(0.0f, 1.0f));

        speed = constantSpeed;
    }
    
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Player"))
            constantSpeed += increaseOverBound;
        else if (collision.gameObject.layer.Equals("Goal"))
        {
            transform.position = new Vector3(0.0f,0.0f,0.0f);
            rb.AddForce(Random.Range(0.0f, 1.0f), 0.5f, Random.Range(0.0f, 1.0f));
            speed = constantSpeed;
        }
    }
}
