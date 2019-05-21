using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public GameObject spawn;
    public GameObject wall1;
    public GameObject wall2;

    public float constantSpeed = 1.0f;
    public float increaseOverBound = 0.01f;

    public static BulletMover Call
    {
        get { return bulletMover; }
    }

    [HideInInspector]
    public float speed;

    private static BulletMover bulletMover = null;

    private BulletMover()
    {
        bulletMover = this;
    }

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
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            speed += increaseOverBound;
            Vector3 worldForward = (transform.forward);
            Vector3 reflection = Vector3.Reflect(worldForward, collision.GetContact(0).normal);
            
            transform.rotation = Quaternion.LookRotation((reflection));
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Wall")
        {
            Vector3 worldForward = (transform.forward);
            Vector3 reflection = Vector3.Reflect(worldForward, collision.GetContact(0).normal);
            transform.rotation = Quaternion.LookRotation(reflection);
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Goal")
        {
            speed = constantSpeed;
            transform.position = spawn.transform.position;
            if (gameObject == wall1)
                transform.rotation = Quaternion.LookRotation(wall1.transform.position - transform.position);
            else
                transform.rotation = Quaternion.LookRotation(wall2.transform.position - transform.position);
            // rb.AddForce(new Vector3(Random.Range(0.0f, 1.0f), 0.0f, Random.Range(0.0f, 1.0f) * constantSpeed), ForceMode.Impulse); speed = constantSpeed;
        }
    }
}
