using UnityEngine;

public class ballPong : MonoBehaviour
{
    GameObject wall1;
    GameObject wall2;

    Rigidbody rb;

    public float constantSpeed = 1.0f;
    public float increaseOverBound = 0.01f;

    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0.0f, transform.position.y, 0.0f);
        rb.AddForce(new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f) * constantSpeed), ForceMode.Impulse);

        speed = constantSpeed;
    }
    
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Player"))
            speed += increaseOverBound;
        else if (collision.gameObject.layer.Equals("Goal"))
        {
            transform.position = new Vector3(0.0f,0.0f,0.0f);
            rb.AddForce(new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f) * constantSpeed), ForceMode.Impulse); speed = constantSpeed;
        }
    }
}
