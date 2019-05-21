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
        speed = constantSpeed;
    }
    
    void Update()
    {
        transform.position += transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals("Player"))
        {
            speed += increaseOverBound;
            Vector3 reflection = Vector3.Reflect(transform.forward, transform.InverseTransformDirection(collision.GetContact(0).normal));
            transform.rotation = Quaternion.LookRotation(reflection);
        }
        else if (collision.gameObject.layer.Equals("Wall"))
        {
            Vector3 reflection = Vector3.Reflect(transform.forward, transform.InverseTransformDirection(collision.GetContact(0).normal));
            transform.rotation = Quaternion.LookRotation(reflection);
        }
        else if (collision.gameObject.layer.Equals("Goal"))
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            rb.AddForce(new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f) * constantSpeed), ForceMode.Impulse); speed = constantSpeed;
        }
    }
}
